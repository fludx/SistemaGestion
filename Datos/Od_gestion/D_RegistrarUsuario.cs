using System;
using System.Data;
using System.Data.SqlClient;
using Datos.Conecction;

namespace Datos
{
    public class D_RegistrarUsuario
    {
        public static bool RegistrarUsuario(
           int idpersona,
           string usuario,
           string contrasena,
           int idrol
        )
        {
            try
            {
                using (SqlConnection conexion = ConnectionBD.ObtenerConexion())
                {
                    conexion.Open();

                    using (SqlCommand cmd = new SqlCommand("sp_RegistrarUsuario", conexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Id_Persona", idpersona);
                        cmd.Parameters.AddWithValue("@Usuario", usuario);
                        cmd.Parameters.AddWithValue("@Contrasena", contrasena);
                        cmd.Parameters.AddWithValue("@Id_Rol", idrol);

                        cmd.ExecuteNonQuery();

                        Console.WriteLine("Usuario registrado correctamente.");
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                // Mostrar mensaje completo del error en consola
                Console.WriteLine("Error en registrar persona: " + ex.ToString());
                return false;
            }
        }
    }
}
