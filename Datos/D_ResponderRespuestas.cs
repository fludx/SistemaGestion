using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Datos.Conecction;
using Datos.DTOs;

namespace Datos
{
    public class D_ResponderRespuestas
    {
        public List<PreguntaDTO> ObtenerRespuestasUsuario(string usuario)
        {
            List<PreguntaDTO> respuestas = new List<PreguntaDTO>();

            using (SqlConnection conexion = ConnectionBD.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("sp_ResponderRespuestas", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Usuario", usuario);

                    conexion.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            respuestas.Add(new PreguntaDTO
                            {
                                IdPregunta = Convert.ToInt32(reader["Id_Pregunta"]),
                                Pregunta = reader["Pregunta"].ToString(),
                                Respuesta = reader["Respuesta"].ToString()
                            });
                        }
                    }
                }
            }

            return respuestas;
        }

        public bool EsRespuestaCorrecta(string usuario, int idPregunta, string respuestaUsuario)
        {
            using (SqlConnection conexion = ConnectionBD.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("sp_ResponderRespuestas", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Usuario", usuario);
                    cmd.Parameters.AddWithValue("@IdPregunta", idPregunta);
                    cmd.Parameters.AddWithValue("@Respuesta", respuestaUsuario);

                    conexion.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read() && reader["RespuestaCorrecta"] != DBNull.Value)
                        {
                            return Convert.ToInt32(reader["RespuestaCorrecta"]) == 1;
                        }
                    }
                }
            }

            return false;
        }

        public bool ValidarRespuestasUsuario(string usuario, Dictionary<int, string> respuestasUsuario, out string mensaje)
        {
            var respuestasCorrectas = ObtenerRespuestasUsuario(usuario);

            foreach (var correcta in respuestasCorrectas)
            {
                if (!respuestasUsuario.TryGetValue(correcta.IdPregunta, out string respuestaIngresada))
                {
                    mensaje = $"Falta respuesta para la pregunta: {correcta.Pregunta}";
                    return false;
                }

                if (!correcta.Respuesta.Equals(respuestaIngresada, StringComparison.OrdinalIgnoreCase))
                {
                    mensaje = $"Respuesta incorrecta para la pregunta: {correcta.Pregunta}";
                    return false;
                }
            }

            Console.WriteLine("El id del usuario que responde respuestas es: " + usuario);
            mensaje = "Todas las respuestas son correctas.";
            return true;
        }
    }
}
