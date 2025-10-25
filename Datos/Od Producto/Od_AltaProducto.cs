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
    public class Od_AltaProducto : Ejeconsultas_Stock
    {
        public bool AltaProducto(ProductoDTO producto)
        {
            try
            {
                string nombreSP = "sp_AltaProducto";

                // Lista de parámetros
                List<SqlParameter> parametros = new List<SqlParameter>
                {
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

                // Si devuelve alguna fila, se considera exitosa la operación
                return dt.Rows.Count > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al dar de alta el producto: " + ex.Message);
            }
        }
    }
}
