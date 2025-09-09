using Datos;
using System.Collections.Generic;
using System.Linq;

namespace Logica
{
    public class L_ResponderRespuestas
    {
        private D_ResponderRespuestas dResponder = new D_ResponderRespuestas();

        public List<PreguntaVista> ObtenerRespuestasDelUsuario(string usuario)
        {
            var listaDTO = dResponder.ObtenerRespuestasUsuario(usuario);

            return listaDTO.Select(p => new PreguntaVista
            {
                Id = p.IdPregunta,
                Pregunta = p.Pregunta,
                RespuestaCorrecta = p.Respuesta
            }).ToList();
        }

        public bool ValidarRespuestas(string usuario, Dictionary<int, string> respuestasUsuario, out string mensaje)
        {
            var listaDTO = dResponder.ObtenerRespuestasUsuario(usuario);

            foreach (var correcta in listaDTO)
            {
                if (!respuestasUsuario.TryGetValue(correcta.IdPregunta, out string respuestaIngresada))
                {
                    mensaje = $"Falta respuesta para la pregunta: {correcta.Pregunta}";
                    return false;
                }

                if (!correcta.Respuesta.Equals(respuestaIngresada, System.StringComparison.OrdinalIgnoreCase))
                {
                    mensaje = $"Respuesta incorrecta para la pregunta: {correcta.Pregunta}";
                    return false;
                }
            }

            mensaje = "Todas las respuestas son correctas.";
            return true;
        }

        public bool EsRespuestaCorrecta(string usuario, int idPregunta, string respuestaUsuario)
        {
            return dResponder.EsRespuestaCorrecta(usuario, idPregunta, respuestaUsuario);
        }

    }
}
