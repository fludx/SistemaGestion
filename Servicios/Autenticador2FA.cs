using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class Autenticador2FA
    {
        private string codigoActual;
        public string GenerarCodigo()
        {
            Random rnd = new Random();
            codigoActual = rnd.Next(100000, 999999).ToString();
            return codigoActual;
        }

        public bool ValidarCodigoIngresado(string codigoIngresado)
        {
            return codigoIngresado == codigoActual;
        }

    }
}
