using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.DTOs
{
    public class PreguntaDTO
    {
        public int IdPregunta { get; set; }
        public string Pregunta { get; set; }

        public string Respuesta { get; set; }
    }
}
