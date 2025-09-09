using Datos.Conecction;
using Datos.DTOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class D_ListarPreguntas
    {
        public List<PreguntaDTO> ListarPreguntas()
        {
            List<PreguntaDTO> lista = new List<PreguntaDTO>();

            try
            {
                using (SqlConnection conexion = ConnectionBD.ObtenerConexion())
                {
                    conexion.Open();

                    using (SqlCommand cmd = new SqlCommand("sp_ListarPreguntas", conexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                PreguntaDTO pregunta = new PreguntaDTO
                                {
                                    IdPregunta = reader["Id_Pregunta"] != DBNull.Value ? Convert.ToInt32(reader["Id_Pregunta"]) : 0,
                                    Pregunta = reader["Pregunta"].ToString(),
                                };


                                lista.Add(pregunta);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar las preguntas: ", ex);
            }

            return lista;
        }
    }
}
