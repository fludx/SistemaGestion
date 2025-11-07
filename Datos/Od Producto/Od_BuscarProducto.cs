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
        public List<ProductoBuscarDTO> BuscarProducto(string? codigo = null, string? nombre = null, int? idProducto = null)
        {
            try
            {
                string nombreSP = "sp_BuscarProducto";

                // Parámetros del procedimiento almacenado
                List<SqlParameter> parametros = new List<SqlParameter>
                {
                    new SqlParameter("@codigo", SqlDbType.VarChar, 50) { Value = (object)codigo ?? DBNull.Value },
                    new SqlParameter("@nombre", SqlDbType.VarChar, 100) { Value = (object)nombre ?? DBNull.Value },
                    new SqlParameter("@id_producto", SqlDbType.Int) { Value = (object)idProducto ?? DBNull.Value }
                };

                SqlParameter[] sqlParam = parametros.ToArray();

                // Ejecutar el SP
                DataTable dt = EjecConsultas(nombreSP, sqlParam);

                // Procesar los resultados
                List<ProductoBuscarDTO> productos = new List<ProductoBuscarDTO>();

                foreach (DataRow row in dt.Rows)
                {
                    productos.Add(new ProductoBuscarDTO
                    {
                        IdProducto = Convert.ToInt32(row["id_producto"]),
                        Codigo = row["codigo"].ToString(),
                        Nombre = row["nombre"].ToString(),
                        Marca = row["marca"].ToString(),
                        Categoria = row["categoria"].ToString(),
                        PrecioCompra = Convert.ToDecimal(row["precio_compra"]),
                        PrecioVenta = Convert.ToDecimal(row["precio_venta"]),
                        StockActual = Convert.ToInt32(row["stock_actual"]),
                        Activo = Convert.ToBoolean(row["activo"])
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
