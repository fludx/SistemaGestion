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
                    new SqlParameter("@codigo", SqlDbType.NVarChar, 50) { Value = (object)producto.Codigo ?? DBNull.Value },
                    new SqlParameter("@id_categoria", SqlDbType.Int) { Value = producto.IdCategoria },
                    new SqlParameter("@nombre", SqlDbType.NVarChar, 150) { Value = (object)producto.Nombre ?? DBNull.Value },
                    new SqlParameter("@descripcion", SqlDbType.NVarChar, 500) { Value = (object)producto.Descripcion ?? DBNull.Value },
                    new SqlParameter("@marca", SqlDbType.NVarChar, 100) { Value = (object)producto.Marca ?? DBNull.Value },
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

                    // Parámetros añadidos para compatibilidad con el SP en BD
                    // Si su DTO incluye estas propiedades, reemplace los valores hardcodeados por producto.PuntoReposicion / producto.TipoStock
                    new SqlParameter("@punto_reposicion", SqlDbType.Int) { Value = 0 },
                    new SqlParameter("@tipo_stock", SqlDbType.NVarChar, 20) { Value = "Existencia" }
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
