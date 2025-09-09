using Datos.Conecction;
using Sesion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class D_Logs
    {
        public List<Log> ListarLogs()
        {
            List<Log> lista = new List<Log>();

            try
            {
                using (SqlConnection conexion = ConnectionBD.ObtenerConexion())
                {
                    conexion.Open();

                    using (SqlCommand cmd = new SqlCommand("sp_ListarLogs", conexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Log log = new Log
                                {
                                    Usuario = reader["Usuario"].ToString(),
                                    Accion = reader["Accion"].ToString(),
                                    Fecha = reader["Fecha"] != DBNull.Value ? Convert.ToDateTime(reader["Fecha"]) : DateTime.MinValue
                                };

                                lista.Add(log);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar los logs: " + ex.Message);
            }

            return lista;
        }

        public void InsertarLog(string usuario, string accion)
        {
            try
            {
                using (SqlConnection conexion = ConnectionBD.ObtenerConexion())
                {
                    conexion.Open();

                    using (SqlCommand cmd = new SqlCommand("sp_InsertarLog", conexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Usuario", usuario ?? string.Empty);
                        cmd.Parameters.AddWithValue("@Accion", accion);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar el log: ", ex);
            }
        }

    }
}
