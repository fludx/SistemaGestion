using Datos.Conecction;
using Datos.DTOs_Stock;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Datos.Od_Stock
{
    public class Od_ModificarProducto : Ejeconsultas_Stock
    {
        public bool ModificarProducto(ProductoModificarDTO producto)
        {
            try
            {
                string nombreSP = "sp_ModificarProducto";

                // Eliminar la línea que hace referencia a "PuntoReposicion" ya que "ProductoModificarDTO" no tiene esa propiedad.
                // Código original:
                // new SqlParameter("@punto_reposicion", SqlDbType.Int) { Value = producto.PuntoReposicion },

                // Código corregido: simplemente elimina esa línea del array de parámetros.
                List<SqlParameter> parametros = new List<SqlParameter>
                {
                    new SqlParameter("@id_producto", SqlDbType.Int) { Value = producto.IdProducto },
                    new SqlParameter("@codigo", SqlDbType.NVarChar, 50) { Value = (object)producto.Codigo ?? DBNull.Value },
                    new SqlParameter("@id_categoria", SqlDbType.Int) { Value = producto.IdCategoria },
                    new SqlParameter("@nombre", SqlDbType.NVarChar, 150) { Value = (object)producto.Nombre ?? DBNull.Value },
                    new SqlParameter("@descripcion", SqlDbType.NVarChar, 500) { Value = (object)producto.Descripcion ?? DBNull.Value },
                    new SqlParameter("@marca", SqlDbType.NVarChar, 100) { Value = (object)producto.Marca ?? DBNull.Value },
                    new SqlParameter("@precio_compra", SqlDbType.Decimal) { Precision = 18, Scale = 2, Value = producto.PrecioCompra },
                    new SqlParameter("@precio_venta", SqlDbType.Decimal) { Precision = 18, Scale = 2, Value = producto.PrecioVenta },
                    new SqlParameter("@stock_minimo", SqlDbType.Int) { Value = producto.StockMinimo },
                    new SqlParameter("@stock_ideal", SqlDbType.Int) { Value = producto.StockIdeal },

new SqlParameter("@tipo_stock", SqlDbType.NVarChar, 20) { Value = "Existencia" },
                    new SqlParameter("@stock_maximo", SqlDbType.Int) { Value = producto.StockMaximo },
                };

                SqlParameter[] sqlParam = parametros.ToArray();

                // Ejecutar como non-query (el SP no retorna filas)
                EjecConsultas(nombreSP, sqlParam, true);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al modificar el producto: " + ex.Message);
            }
        }
    }
}
