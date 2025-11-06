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
    public class Od_ListarProductos : Ejeconsultas_Stock
    {
        public List<ProductoListadoDTO> ListarProductos(int? idCategoria = null, bool? activo = null)
        {
            try
            {
                string nombreSP = "sp_ListarProductos";

                // Parámetros del procedimiento almacenado
                List<SqlParameter> parametros = new List<SqlParameter>
                {
                    new SqlParameter("@id_categoria", SqlDbType.Int) { Value = (object)idCategoria ?? DBNull.Value },
                    new SqlParameter("@activo", SqlDbType.Bit) { Value = (object)activo ?? DBNull.Value }
                };

                SqlParameter[] sqlParam = parametros.ToArray();

                // Ejecutar el SP y obtener los datos
                DataTable dt = EjecConsultas(nombreSP, sqlParam);

                // Procesar el resultado
                List<ProductoListadoDTO> listaProductos = new List<ProductoListadoDTO>();

                foreach (DataRow row in dt.Rows)
                {
                    listaProductos.Add(new ProductoListadoDTO
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

                return listaProductos;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar los productos: " + ex.Message);
            }
        }
    }
}
