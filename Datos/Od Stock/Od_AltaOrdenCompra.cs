using Datos.Conecction;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Od_Stock
{
    public class Od_AltaOrdenCompra : Ejeconsultas_Stock
    {
        public int AltaOrdenCompra(int proveedorId, DateTime fecha, string estado)
        {
            try
            {
                string NombreSP = "sp_AltaOrdenCompra";

                SqlParameter[] sqlParam = new SqlParameter[]
                {
            new SqlParameter("@ProveedorID", SqlDbType.Int) { Value = proveedorId },
            new SqlParameter("@Fecha", SqlDbType.Date) { Value = fecha },
            new SqlParameter("@Estado", SqlDbType.NVarChar, 50) { Value = estado }
                };

                // Ejecutamos el SP que devuelve un DataTable con "NuevaOrdenID"
                DataTable dt = EjecConsultas(NombreSP, sqlParam);

                if (dt.Rows.Count > 0)
                {
                    return Convert.ToInt32(dt.Rows[0]["NuevaOrdenID"]);
                }
                else
                {
                    throw new Exception("No se generó la orden de compra.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
