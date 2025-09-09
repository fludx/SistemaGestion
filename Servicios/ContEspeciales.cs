using System;

namespace Servicios
{
    public class ContEspeciales
    {
        public bool ContieneCaracterEspecial(string contra)
        {
            foreach (char c in contra)
            {
                if (!char.IsLetterOrDigit(c))
                    return true;
            }

            return false;
        }
    }
}
