using System;

namespace Servicios
{
    public class ContNum
    {
        public string ContieneNumeros(string contra)
        {
            foreach (char c in contra)
            {
                if (char.IsDigit(c))
                {
                    return contra;
                }
            }

            return "La contraseña debe contener al menos un número.";
        }
    }
}
