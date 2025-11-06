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
    public class Od_RegistrarScrap : Ejeconsultas_Stock
    {
        public bool RegistrarScrap(ScrapDTO scrap)
        {
            try
            {
                string nombreSP = "sp_RegistrarScrap";

                // Parámetros del procedimiento almacenado
                List<SqlParameter> parametros = new List<SqlParameter>
                {
                    new SqlParameter("@id_producto", SqlDbType.Int) { Value = scrap.IdProducto },
                    new SqlParameter("@cantidad", SqlDbType.Int) { Value = scrap.Cantidad },
                    new SqlParameter("@motivo", SqlDbType.NVarChar, 255) { Value = (object)scrap.Motivo ?? DBNull.Value },
                    new SqlParameter("@fecha_scrap", SqlDbType.DateTime2) { Value = scrap.FechaScrap }
                };

                SqlParameter[] sqlParam = parametros.ToArray();

                // Ejecutar el SP
                DataTable dt = EjecConsultas(nombreSP, sqlParam);

                // Si devuelve filas (por ejemplo, con SCOPE_IDENTITY), se considera éxito
                return dt.Rows.Count > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al registrar el scrap de producto: " + ex.Message);
            }
        }
    }
}
