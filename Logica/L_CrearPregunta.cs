using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class L_Pregunta
    {
        public bool CrearPregunta(string pregunta, out string mensaje)
        {
            return D_CrearPregunta.CrearPregunta(pregunta, out mensaje);
        }
    }
}
