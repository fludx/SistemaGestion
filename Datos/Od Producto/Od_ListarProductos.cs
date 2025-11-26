using Datos.Conecction;
using Datos.DTOs_Stock;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Datos.Od_Stock
{
    public class Od_ListarProductos : Ejeconsultas_Stock
    {
        public List<ProductoListadoDTO> ListarProductos(int? idCategoria = null, bool? activo = null)
        {
            try
            {
                // Usar el SP existente que devuelve los productos y la columna categoria_nombre
                string nombreSP = "sp_ListarProductos";
                SqlParameter[] sqlParam = new SqlParameter[0];

                DataTable dt = EjecConsultas(nombreSP, sqlParam);

                // Obtener stock total por producto (SP existente)
                var stockTotals = new Dictionary<int, int>();
                try
                {
                    var dtStock = EjecConsultas("sp_ReporteStockGeneral", new SqlParameter[0]);
                    foreach (DataRow r in dtStock.Rows)
                    {
                        if (r.Table.Columns.Contains("id_producto") && r.Table.Columns.Contains("stock_total") &&
                            r["id_producto"] != DBNull.Value && r["stock_total"] != DBNull.Value)
                        {
                            int id = Convert.ToInt32(r["id_producto"]);
                            int tot = Convert.ToInt32(r["stock_total"]);
                            stockTotals[id] = tot;
                        }
                    }
                }
                catch
                {
                    // si falla el SP de stock, seguimos sin stock totals (no interrumpir listado)
                }

                var listaProductos = new List<ProductoListadoDTO>();

                foreach (DataRow row in dt.Rows)
                {
                    int idProd = row.Table.Columns.Contains("id_producto") && row["id_producto"] != DBNull.Value
                        ? Convert.ToInt32(row["id_producto"]) : 0;

                    string codigo = row.Table.Columns.Contains("codigo") && row["codigo"] != DBNull.Value
                        ? row["codigo"].ToString() : "";

                    string nombre = row.Table.Columns.Contains("nombre") && row["nombre"] != DBNull.Value
                        ? row["nombre"].ToString() : "";

                    string marca = row.Table.Columns.Contains("marca") && row["marca"] != DBNull.Value
                        ? row["marca"].ToString() : "";

                    string categoria = "";
                    if (row.Table.Columns.Contains("categoria_nombre") && row["categoria_nombre"] != DBNull.Value)
                        categoria = row["categoria_nombre"].ToString();
                    else if (row.Table.Columns.Contains("categoria") && row["categoria"] != DBNull.Value)
                        categoria = row["categoria"].ToString();

                    decimal precioCompra = row.Table.Columns.Contains("precio_compra") && row["precio_compra"] != DBNull.Value
                        ? Convert.ToDecimal(row["precio_compra"]) : 0m;

                    decimal precioVenta = row.Table.Columns.Contains("precio_venta") && row["precio_venta"] != DBNull.Value
                        ? Convert.ToDecimal(row["precio_venta"]) : 0m;

                    int stockActual = 0;
                    if (stockTotals.ContainsKey(idProd)) stockActual = stockTotals[idProd];
                    else if (row.Table.Columns.Contains("stock_actual") && row["stock_actual"] != DBNull.Value)
                        stockActual = Convert.ToInt32(row["stock_actual"]);

                    bool activoFlag = true;
                    if (row.Table.Columns.Contains("activo") && row["activo"] != DBNull.Value)
                        activoFlag = Convert.ToBoolean(row["activo"]);

                    listaProductos.Add(new ProductoListadoDTO
                    {
                        IdProducto = idProd,
                        Codigo = codigo,
                        Nombre = nombre,
                        Marca = marca,
                        Categoria = categoria,
                        PrecioCompra = precioCompra,
                        PrecioVenta = precioVenta,
                        StockActual = stockActual,
                        Activo = activoFlag
                    });
                }

                return listaProductos;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar los productos: " + ex.Message);
            }
        }
    }
}
