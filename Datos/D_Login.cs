using Datos.Conecction;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class D_Login
    {
        public static int LoginBD(string usuario, string contrasena, out bool esAdmin, out string nombreRol)
        {
            int idUsuario = -1;
            esAdmin = false;
            nombreRol = null;

            using (SqlConnection conn = ConnectionBD.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_Login", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Usuario", usuario);
                cmd.Parameters.AddWithValue("@Contrasena", contrasena);

                SqlParameter adminParam = new SqlParameter("@EsAdmin", SqlDbType.Bit)
                {
                    Direction = ParameterDirection.Output
                };
                SqlParameter rolParam = new SqlParameter("@NombreRol", SqlDbType.NVarChar, 50)
                {
                    Direction = ParameterDirection.Output
                };

                cmd.Parameters.Add(adminParam);
                cmd.Parameters.Add(rolParam);

                conn.Open();
                var result = cmd.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int id))
                {
                    idUsuario = id;
                }

                esAdmin = (bool)adminParam.Value;
                nombreRol = rolParam.Value.ToString();
            }

            return idUsuario;
        }
    }
}