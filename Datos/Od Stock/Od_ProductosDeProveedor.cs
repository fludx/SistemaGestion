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
    public class Od_ProductosDeProveedor : Ejeconsultas_Stock
    {
        public List<ProductoProveedorDTO> ConsultarProductosDeProveedor(int idProveedor)
        {
            try
            {
                string nombreSP = "sp_ConsultarProductosDeProveedor";

                // Parámetros del procedimiento almacenado
                List<SqlParameter> parametros = new List<SqlParameter>
                {
                    new SqlParameter("@id_proveedor", SqlDbType.Int) { Value = idProveedor }
                };

                SqlParameter[] sqlParam = parametros.ToArray();

                // Ejecutar el SP y obtener el DataTable
                DataTable dt = EjecConsultas(nombreSP, sqlParam);

                // Procesar el resultado y devolver una lista de DTOs
                List<ProductoProveedorDTO> productos = new List<ProductoProveedorDTO>();
                foreach (DataRow row in dt.Rows)
                {
                    productos.Add(new ProductoProveedorDTO
                    {
                        IdProducto = Convert.ToInt32(row["id_producto"]),
                        Codigo = row["codigo"].ToString(),
                        NombreProducto = row["nombre_producto"].ToString(),
                        Marca = row["marca"].ToString(),
                        PrecioCompra = Convert.ToDecimal(row["precio_compra"]),
                        PrecioVenta = Convert.ToDecimal(row["precio_venta"]),
                        StockMinimo = Convert.ToInt32(row["stock_minimo"]),
                        StockIdeal = Convert.ToInt32(row["stock_ideal"]),
                        StockMaximo = Convert.ToInt32(row["stock_maximo"])
                    });
                }

                return productos;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar los productos del proveedor: " + ex.Message);
            }
        }
    }
}