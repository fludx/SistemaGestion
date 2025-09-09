using Datos;
using Datos.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class L_ResponderPreguntas
    {
        internal D_ListarPreguntas dpreguntas = new D_ListarPreguntas();

        public List<KeyValuePair<int, string>> lListarPreguntas()
        {
            var preguntas = dpreguntas.ListarPreguntas();

            var listapreguntas = new List<KeyValuePair<int, string>>();
            foreach (var pregunta in preguntas)
            {
                listapreguntas.Add(new KeyValuePair<int, string>(pregunta.IdPregunta, pregunta.Pregunta));
            }

            return listapreguntas;
        }

        public List<PreguntaVista> ObtenerPreguntaAleatoria(int cantidad)
        {
            var preguntas = dpreguntas.ListarPreguntas();

            Random rng = new Random();
            int n = preguntas.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                var temp = preguntas[k];
                preguntas[k] = preguntas[n];
                preguntas[n] = temp;
            }

            return preguntas.Take(Math.Min(cantidad, preguntas.Count))
                .Select(p => new PreguntaVista
                {
                    Id = p.IdPregunta,
                    Pregunta = p.Pregunta,
                    Respuesta = p.Respuesta
                }).ToList();
        }
    public class L_ResponderPregunta
        {
            public bool ResponderPregunta(int idUsuario, int idPregunta, string respuesta, out string mensaje)
            {
                return D_CrearRespuesta.CrearRespuesta(idUsuario, idPregunta, respuesta, out mensaje);
            }
        }
    }
}
