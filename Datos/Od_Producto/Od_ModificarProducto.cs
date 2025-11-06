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
    public class Od_ModificarProducto : Ejeconsultas_Stock
    {
        public bool ModificarProducto(ProductoModificarDTO producto)
        {
            try
            {
                string nombreSP = "sp_ModificarProducto";

                // Lista de parámetros
                List<SqlParameter> parametros = new List<SqlParameter>
                {
                    new SqlParameter("@id_producto", SqlDbType.Int) { Value = producto.IdProducto },
                    new SqlParameter("@codigo", SqlDbType.VarChar, 50) { Value = producto.Codigo },
                    new SqlParameter("@nombre", SqlDbType.VarChar, 100) { Value = producto.Nombre },
                    new SqlParameter("@marca", SqlDbType.VarChar, 100) { Value = (object)producto.Marca ?? DBNull.Value },
                    new SqlParameter("@descripcion", SqlDbType.VarChar, 255) { Value = (object)producto.Descripcion ?? DBNull.Value },
                    new SqlParameter("@precio_compra", SqlDbType.Decimal)
                    {
                        Precision = 18,
                        Scale = 2,
                        Value = producto.PrecioCompra
                    },
                    new SqlParameter("@precio_venta", SqlDbType.Decimal)
                    {
                        Precision = 18,
                        Scale = 2,
                        Value = producto.PrecioVenta
                    },
                    new SqlParameter("@stock_minimo", SqlDbType.Int) { Value = producto.StockMinimo },
                    new SqlParameter("@stock_ideal", SqlDbType.Int) { Value = producto.StockIdeal },
                    new SqlParameter("@stock_maximo", SqlDbType.Int) { Value = producto.StockMaximo },
                    new SqlParameter("@id_categoria", SqlDbType.Int) { Value = producto.IdCategoria },
                    new SqlParameter("@activo", SqlDbType.Bit) { Value = producto.Activo }
                };

                SqlParameter[] sqlParam = parametros.ToArray();

                // Ejecutar el SP
                DataTable dt = EjecConsultas(nombreSP, sqlParam);

                // Si el SP retorna filas, se considera que se ejecutó correctamente
                return dt.Rows.Count > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al modificar el producto: " + ex.Message);
            }
        }
    }
}
