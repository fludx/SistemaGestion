using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class MinCaracteres
    {
        public static string ValidarMinimoCaracteres(string input, int minLength)
        {
            if (string.IsNullOrEmpty(input))
            {
                return $"El campo no puede estar vacío. Debe tener al menos {minLength} caracteres.";
            }else if (input.Length < minLength)
            {
                return $"El campo debe tener al menos {minLength} caracteres. Actualmente tiene {input.Length}.";
            }
            return input;
        }
    }
}
