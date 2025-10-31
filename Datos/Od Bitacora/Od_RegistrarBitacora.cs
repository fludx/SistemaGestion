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
    public class Od_RegistrarBitacora : Ejeconsultas_Stock
    {
        public bool RegistrarBitacora(BitacoraDTO bitacora)
        {
            try
            {
                string nombreSP = "sp_RegistrarBitacora";

                // Lista de parámetros
                List<SqlParameter> parametros = new List<SqlParameter>
                {
                    new SqlParameter("@id_usuario", SqlDbType.Int) { Value = bitacora.IdUsuario },
                    new SqlParameter("@accion", SqlDbType.NVarChar, 100) { Value = bitacora.Accion },
                    new SqlParameter("@modulo", SqlDbType.NVarChar, 100) { Value = (object)bitacora.Modulo ?? DBNull.Value },
                    new SqlParameter("@descripcion", SqlDbType.NVarChar, 500) { Value = (object)bitacora.Descripcion ?? DBNull.Value },
                    new SqlParameter("@fecha_registro", SqlDbType.DateTime2) { Value = bitacora.FechaRegistro }
                };

                SqlParameter[] sqlParam = parametros.ToArray();

                // Ejecutar el procedimiento almacenado
                DataTable dt = EjecConsultas(nombreSP, sqlParam);

                // Si devuelve filas, la operación fue exitosa
                return dt.Rows.Count > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al registrar en la bitácora: " + ex.Message);
            }
        }
    }
}
