using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class PreguntaVista
    {
        public int Id { get; set; }
        public string Pregunta { get; set; }
        public string Respuesta { get; set; } = string.Empty;
        public string RespuestaCorrecta { get; set; }
    }
}
