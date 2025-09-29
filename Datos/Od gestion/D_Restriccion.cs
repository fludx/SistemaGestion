using System;
using System.Data;
using System.Data.SqlClient;
using Datos.Conecction;
using Sesion;

namespace Datos
{
    public class D_Restriccion
    {
        public EstadoRestricciones ObtenerRestricciones()
        {
            var estado = new EstadoRestricciones();

            try
            {
                using (SqlConnection conexion = ConnectionBD.ObtenerConexion())
                {
                    conexion.Open();

                    using (SqlCommand cmd = new SqlCommand("sp_ObtenerRestricciones", conexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string restriccion = reader["Restriccion"]?.ToString() ?? "";
                                bool activo = reader["Activo"] != DBNull.Value && Convert.ToBoolean(reader["Activo"]);

                                if (!activo)
                                    continue;

                                switch (restriccion)
                                {
                                    case "Mínimo de caracteres":
                                        estado.MinimoCar = 1;
                                        estado.CaracteresUtilizados = Convert.ToInt32(reader["Caracteres_Min"]);
                                        break;
                                    case "Combinar mayúsculas y minúsculas":
                                        estado.MayusMinus = 1;
                                        break;
                                    case "Contener números y letras":
                                        estado.NumeroLetras = 1;
                                        break;
                                    case "Contener un carácter especial":
                                        estado.CaracterEsp = 1;
                                        break;
                                    case "No repetir contraseñas anteriores":
                                        estado.ContrasenaAnterior = 1;
                                        break;
                                    case "No permitir datos personales":
                                        estado.DatosPersonales = 1;
                                        
                                        break;
                                    case "Requerir autenticación en dos pasos (2FA) por correo electrónico":
                                        estado.DosFA = 1;
                                        break;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener restricciones: " + ex.Message);
            }

            return estado;
        }

        public string VerificarContrasena(int idUsuario, string nuevaContrasena)
        {
            using (SqlConnection conexion = ConnectionBD.ObtenerConexion())
            {
                using (SqlCommand comando = new SqlCommand("sp_VerificarContrasenas", conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@Id_Usuario", idUsuario);
                    comando.Parameters.AddWithValue("@NuevaContrasena", nuevaContrasena);

                    try
                    {
                        conexion.Open();
                        comando.ExecuteNonQuery();
                        return "OK";
                    }
                    catch (SqlException ex)
                    {
                        return ex.Message;
                    }
                }
            }
        }
        public void GuardarRestricciones(
            decimal minCaracteres,
            bool mayusMinus,
            bool numLetras,
            bool caracterEspecial,
            bool noRepetir,
            bool noDatosPersonales,
            bool dosFA)
        {
            try
            {
                using (SqlConnection conexion = ConnectionBD.ObtenerConexion())
                {
                    conexion.Open();

                    MandarRestriccion(conexion, "Mínimo de caracteres", minCaracteres.ToString(), true);
                    MandarRestriccion(conexion, "Combinar mayúsculas y minúsculas", "0", mayusMinus);
                    MandarRestriccion(conexion, "Contener números y letras", "0", numLetras);
                    MandarRestriccion(conexion, "Contener un carácter especial", "0", caracterEspecial);
                    MandarRestriccion(conexion, "No repetir contraseñas anteriores", "0", noRepetir);
                    MandarRestriccion(conexion, "No permitir datos personales", "0", noDatosPersonales);
                    MandarRestriccion(conexion, "Requerir autenticación en dos pasos (2FA) por correo electrónico", "0", dosFA);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al guardar restricciones: " + ex.Message);
            }
        }

        private void MandarRestriccion(SqlConnection conexion, string nombre, string caracteresMin, bool activo)
        {
            using (SqlCommand cmd = new SqlCommand("sp_ActualizarRestriccion", conexion))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Restriccion", nombre);
                cmd.Parameters.AddWithValue("@Caracteres_Min", caracteresMin);
                cmd.Parameters.AddWithValue("@Activo", activo);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
