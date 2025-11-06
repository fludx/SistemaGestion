using Datos.Conecction;
using Datos.DTOs;

using System;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class D_ModificarUsuario
    {
        public static UsuarioDTO ObtenerUsuarioPorId(int idUsuario, out string mensaje)
        {
            mensaje = null;
            UsuarioDTO usuario = null;

            try
            {
                using (SqlConnection conexion = ConnectionBD.ObtenerConexion())
                {
                    conexion.Open();

                    using (SqlCommand cmd = new SqlCommand("sp_ObtenerUsuarioPorId", conexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Id_Usuario", idUsuario);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                usuario = new UsuarioDTO
                                {
                                    Id_Usuario = reader.GetInt32(reader.GetOrdinal("Id_Usuario")),
                                    Id_Persona = reader.GetInt32(reader.GetOrdinal("Id_Persona")),
                                    Usuario = reader.GetString(reader.GetOrdinal("Usuario")),
                                    Contrasena = reader.GetString(reader.GetOrdinal("Contrasena")),
                                    Bloqueado = reader.GetBoolean(reader.GetOrdinal("Bloqueado")),
                                    Fecha_Bloqueo = reader.IsDBNull(reader.GetOrdinal("Fecha_Bloqueo"))? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("Fecha_Bloqueo")),
                                    CambioContra = reader.GetInt32(reader.GetOrdinal("CambioContra")),
                                    FechaCambioContra = reader.IsDBNull(reader.GetOrdinal("FechaCambioContra"))? (DateTime?)null: reader.GetDateTime(reader.GetOrdinal("FechaCambioContra")),
                                    Id_Rol = reader.GetInt32(reader.GetOrdinal("Id_Rol"))
                                };

                                mensaje = "Usuario encontrado correctamente.";
                            }
                            else
                            {
                                mensaje = "No se encontró un usuario con ese ID.";
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                mensaje = "Error SQL: " + ex.Message;
            }
            catch (Exception ex)
            {
                mensaje = "Error inesperado: " + ex.Message;
            }

            return usuario;
        }

        public static bool ActualizarUsuario(UsuarioDTO usuario, out string mensaje)
        {
            mensaje = null;
            try
            {
                using (SqlConnection conexion = ConnectionBD.ObtenerConexion())
                {
                    conexion.Open();

                    using (SqlCommand cmd = new SqlCommand("sp_ActualizarUsuario", conexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Id_Usuario", usuario.Id_Usuario);
                        cmd.Parameters.AddWithValue("@Usuario", usuario.Usuario);
                        cmd.Parameters.AddWithValue("@Bloqueado", usuario.Bloqueado);
                        cmd.Parameters.AddWithValue("@Fecha_Bloqueo", (object)usuario.Fecha_Bloqueo ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@CambioContra", usuario.CambioContra);
                        cmd.Parameters.AddWithValue("@FechaCambioContra", (object)usuario.FechaCambioContra ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Id_Rol", usuario.Id_Rol);

                        object result = cmd.ExecuteScalar();
                        int filasAfectadas = (result != null) ? Convert.ToInt32(result) : 0;

                        if (filasAfectadas > 0)
                        {
                            mensaje = "Usuario actualizado correctamente.";
                            return true;
                        }
                        else
                        {
                            mensaje = "No se actualizó ningún registro.";
                            return false;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                var sb = new System.Text.StringBuilder();
                sb.AppendLine("Error SQL:");
                foreach (SqlError error in ex.Errors)
                {
                    sb.AppendLine($" - Mensaje: {error.Message}");
                    sb.AppendLine($" - Origen: {error.Source}");
                    sb.AppendLine($" - Procedimiento: {error.Procedure}");
                    sb.AppendLine($" - Línea: {error.LineNumber}");
                }
                sb.AppendLine("StackTrace:");
                sb.AppendLine(ex.StackTrace);

                mensaje = sb.ToString();
                return false;
            }
            catch (Exception ex)
            {
                mensaje = $"Error inesperado: {ex.Message}\nStackTrace: {ex.StackTrace}";
                return false;
            }
        }

        public static bool BloquearUsuario(int idUsuario, bool bloquear, DateTime? fechaBloqueo, out string mensaje)
        {
            mensaje = null;
            try
            {
                using (SqlConnection conn = ConnectionBD.ObtenerConexion())
                using (SqlCommand cmd = new SqlCommand("sp_BloquearUsuario", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Id_Usuario", idUsuario);
                    cmd.Parameters.AddWithValue("@Bloqueado", bloquear);

                    if (fechaBloqueo.HasValue)
                        cmd.Parameters.AddWithValue("@Fecha_Bloqueo", fechaBloqueo.Value);
                    else
                        cmd.Parameters.AddWithValue("@Fecha_Bloqueo", DBNull.Value);

                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();

                    return rows > 0;
                }
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
                return false;
            }
        }
    }


}
