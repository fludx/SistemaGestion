using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sesion
{
    public class EstadoRestricciones
    {
        public int MinimoCar { get; set; }
        public int MayusMinus { get; set; }
        public int NumeroLetras { get; set; }
        public int CaracterEsp { get; set; }
        public int ContrasenaAnterior { get; set; }
        public int DatosPersonales { get; set; }
        public int DosFA { get; set; }

        // Caracteres mínimos requeridos
        public int CaracteresUtilizados { get; set; }
    }
}