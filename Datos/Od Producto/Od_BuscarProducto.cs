    using Datos.Conecction;
using Datos.DTOs_Stock;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Od_Stock
{
    public class Od_BuscarProducto : Ejeconsultas_Stock
    {
        public List<ProductoBuscarDTO> BuscarProducto(string codigo = null, string nombre = null, int? idProducto = null)
        {
            try
            {
                string nombreSP = "sp_BuscarProducto";

                List<SqlParameter> parametros = new List<SqlParameter>
                {
                    new SqlParameter("@codigo", SqlDbType.VarChar, 50) { Value = (object)codigo ?? DBNull.Value },
                    new SqlParameter("@nombre", SqlDbType.VarChar, 150) { Value = (object)nombre ?? DBNull.Value },
                    // pasar DBNull para parámetros opcionales que el SP pueda aceptar
                    new SqlParameter("@id_categoria", SqlDbType.Int) { Value = DBNull.Value },
                    new SqlParameter("@marca", SqlDbType.VarChar, 100) { Value = DBNull.Value }
                };

                SqlParameter[] sqlParam = parametros.ToArray();

                DataTable dt = EjecConsultas(nombreSP, sqlParam);

                List<ProductoBuscarDTO> productos = new List<ProductoBuscarDTO>();

                foreach (DataRow row in dt.Rows)
                {
                    int idProd = row.Table.Columns.Contains("id_producto") && row["id_producto"] != DBNull.Value ? Convert.ToInt32(row["id_producto"]) : 0;
                    string codigoRow = row.Table.Columns.Contains("codigo") && row["codigo"] != DBNull.Value ? row["codigo"].ToString() : "";
                    string nombreRow = row.Table.Columns.Contains("nombre") && row["nombre"] != DBNull.Value ? row["nombre"].ToString() : "";
                    string marcaRow = row.Table.Columns.Contains("marca") && row["marca"] != DBNull.Value ? row["marca"].ToString() : "";

                    // categoría: tolerancia a alias
                    string categoriaRow = "";
                    if (row.Table.Columns.Contains("categoria") && row["categoria"] != DBNull.Value) categoriaRow = row["categoria"].ToString();
                    else if (row.Table.Columns.Contains("categoria_nombre") && row["categoria_nombre"] != DBNull.Value) categoriaRow = row["categoria_nombre"].ToString();
                    else if (row.Table.Columns.Contains("nombre_categoria") && row["nombre_categoria"] != DBNull.Value) categoriaRow = row["nombre_categoria"].ToString();

                    decimal precioCompra = row.Table.Columns.Contains("precio_compra") && row["precio_compra"] != DBNull.Value ? Convert.ToDecimal(row["precio_compra"]) : 0m;
                    decimal precioVenta = row.Table.Columns.Contains("precio_venta") && row["precio_venta"] != DBNull.Value ? Convert.ToDecimal(row["precio_venta"]) : 0m;
                    int stockActual = row.Table.Columns.Contains("stock_actual") && row["stock_actual"] != DBNull.Value ? Convert.ToInt32(row["stock_actual"]) : 0;

                    // Nuevos mapeos: stock mínimo, ideal y máximo si vienen desde el SP
                    int stockMinimo = row.Table.Columns.Contains("stock_minimo") && row["stock_minimo"] != DBNull.Value ? Convert.ToInt32(row["stock_minimo"]) : 0;
                    int stockIdeal = row.Table.Columns.Contains("stock_ideal") && row["stock_ideal"] != DBNull.Value ? Convert.ToInt32(row["stock_ideal"]) : 0;
                    int stockMaximo = row.Table.Columns.Contains("stock_maximo") && row["stock_maximo"] != DBNull.Value ? Convert.ToInt32(row["stock_maximo"]) : 0;

                    bool activo = row.Table.Columns.Contains("activo") && row["activo"] != DBNull.Value ? Convert.ToBoolean(row["activo"]) : true;

                    productos.Add(new ProductoBuscarDTO
                    {
                        IdProducto = idProd,
                        Codigo = codigoRow,
                        Nombre = nombreRow,
                        Marca = marcaRow,
                        Categoria = categoriaRow,
                        PrecioCompra = precioCompra,
                        PrecioVenta = precioVenta,
                        StockActual = stockActual,
                        StockMinimo = stockMinimo,
                        StockIdeal = stockIdeal,
                        StockMaximo = stockMaximo,
                        Activo = activo
                    });
                }

                return productos;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar el producto: " + ex.Message);
            }
        }
    }
}
