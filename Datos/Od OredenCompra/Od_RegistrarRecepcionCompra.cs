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
    public class Od_RegistrarRecepcionCompra : Ejeconsultas_Stock
    {
        public bool RegistrarRecepcionCompra(RecepcionCompraRegistrarDTO recepcion)
        {
            try
            {
                string nombreSP = "sp_RegistrarRecepcionCompra";

                // Parámetros del SP
                List<SqlParameter> parametros = new List<SqlParameter>
                {
                    new SqlParameter("@id_orden_compra", SqlDbType.Int) { Value = recepcion.IdOrdenCompra },
                    new SqlParameter("@fecha_recepcion", SqlDbType.Date) { Value = recepcion.FechaRecepcion },
                    new SqlParameter("@numero_remito", SqlDbType.NVarChar, 50) { Value = (object)recepcion.NumeroRemito ?? DBNull.Value },
                    new SqlParameter("@observaciones", SqlDbType.NVarChar, 255) { Value = (object)recepcion.Observaciones ?? DBNull.Value }
                };

                SqlParameter[] sqlParam = parametros.ToArray();

                // Ejecutar el SP
                DataTable dt = EjecConsultas(nombreSP, sqlParam);

                // Si devuelve filas, consideramos la ejecución exitosa
                return dt.Rows.Count > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al registrar la recepción de compra: " + ex.Message);
            }
        }
    }
}
