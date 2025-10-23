using Datos.Conecction;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.DTOs_Stock;


namespace Datos.Od_Stock
{
    public class Od_AgregarDetalleOrdenCompra : Ejeconsultas_Stock
    {
        public bool AgregarDetalleCompra(DetalleOrdenCompraDTO detalle)
        {
            try
            {
                string nombreSP = "sp_AgregarDetalleCompra";

                // Crear lista de parámetros para el SP
                List<SqlParameter> parametros = new List<SqlParameter>
                {
                    new SqlParameter("@id_orden_compra", SqlDbType.Int) { Value = detalle.IdOrdenCompra },
                    new SqlParameter("@id_producto", SqlDbType.Int) { Value = detalle.IdProducto },
                    new SqlParameter("@lote", SqlDbType.NVarChar, 50) { Value = (object)detalle.Lote ?? DBNull.Value },
                    new SqlParameter("@vencimiento", SqlDbType.Date) { Value = (object)detalle.Vencimiento ?? DBNull.Value },
                    new SqlParameter("@cantidad", SqlDbType.Int) { Value = detalle.Cantidad },
                    new SqlParameter("@precio_unitario", SqlDbType.Decimal)
                    {
                        Precision = 18,
                        Scale = 2,
                        Value = (object)detalle.PrecioUnitario ?? DBNull.Value
                    }
                };

                SqlParameter[] sqlParam = parametros.ToArray();

                // Ejecutar SP y verificar si afectó filas
                DataTable dt = EjecConsultas(nombreSP, sqlParam);
                return dt.Rows.Count > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar detalle de orden de compra: " + ex.Message);
            }
        }
    }
}