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
    public class Od_RegistrarEntregaVenta : Ejeconsultas_Stock
    {
        public bool RegistrarEntregaVenta(EntregaVentaDTO entrega)
        {
            try
            {
                string nombreSP = "sp_RegistrarEntregaVenta";

                // Parámetros del procedimiento almacenado
                List<SqlParameter> parametros = new List<SqlParameter>
                {
                    new SqlParameter("@id_venta", SqlDbType.Int) { Value = entrega.IdVenta },
                    new SqlParameter("@fecha_entrega", SqlDbType.DateTime2) { Value = entrega.FechaEntrega },
                    new SqlParameter("@numero_remito", SqlDbType.NVarChar, 50) { Value = (object)entrega.NumeroRemito ?? DBNull.Value },
                    new SqlParameter("@observaciones", SqlDbType.NVarChar, 255) { Value = (object)entrega.Observaciones ?? DBNull.Value }
                };

                SqlParameter[] sqlParam = parametros.ToArray();

                // Ejecutar el procedimiento
                DataTable dt = EjecConsultas(nombreSP, sqlParam);

                // Si devuelve filas (por ejemplo, SCOPE_IDENTITY()), consideramos la operación exitosa
                return dt.Rows.Count > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al registrar la entrega de venta: " + ex.Message);
            }
        }
    }
}
