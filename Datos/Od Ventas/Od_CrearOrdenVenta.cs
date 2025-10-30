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
    public class Od_CrearOrdenVenta : Ejeconsultas_Stock
    {
        public bool CrearOrdenVenta(OrdenVentaDTO venta)
        {
            try
            {
                string nombreSP = "sp_CrearOrdenVenta";

                // Lista de parámetros
                List<SqlParameter> parametros = new List<SqlParameter>
                {
                    new SqlParameter("@id_cliente", SqlDbType.Int) { Value = venta.IdCliente },
                    new SqlParameter("@fecha_venta", SqlDbType.DateTime2) { Value = venta.FechaVenta },
                    new SqlParameter("@metodo_pago", SqlDbType.NVarChar, 100) { Value = (object)venta.MetodoPago ?? DBNull.Value },
                    new SqlParameter("@total", SqlDbType.Decimal)
                    {
                        Precision = 18,
                        Scale = 2,
                        Value = venta.Total
                    },
                    new SqlParameter("@observaciones", SqlDbType.NVarChar, 255)
                    {
                        Value = (object)venta.Observaciones ?? DBNull.Value
                    }
                };

                SqlParameter[] sqlParam = parametros.ToArray();

                // Ejecutar el SP
                DataTable dt = EjecConsultas(nombreSP, sqlParam);

                // Si devuelve filas (SCOPE_IDENTITY), consideramos exitosa la operación
                return dt.Rows.Count > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear la orden de venta: " + ex.Message);
            }
        }
    }
}
