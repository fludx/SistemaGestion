using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class MinimoContra
    {
        // Debemos extraer del DTO de la capa logica el número de caracteres que debe tener la contraseña, EN LA TABLA Restricciones 
        public static void ValidarMinimoCaracteres(string password, int minimoContra)
        {
            if (password.Length < minimoContra)
            {
                throw new Exception("La contraseña debe tener al menos" + " caracteres");
            }
        }
    }
}
