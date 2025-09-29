using Datos.Conecction;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class D_CambioObligatorio
    {
        public static bool ActualizarContra(int idUsuario, string contrasena, DateTime fechacambio)
        {
            try
            {
                using (SqlConnection conexion = ConnectionBD.ObtenerConexion())
                {
                    conexion.Open();

                    using (SqlCommand cmd = new SqlCommand("sp_ActualizarContra", conexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@id_usuario", idUsuario);
                        cmd.Parameters.AddWithValue("@contrasena", contrasena);
                        cmd.Parameters.AddWithValue("@fechacambio", fechacambio);

                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception($"Error SQL: {ex.Message}", ex);
            }
        }
    }
}
