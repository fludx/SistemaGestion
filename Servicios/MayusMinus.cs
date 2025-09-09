using System;

namespace Servicios
{
    public class MayusMinus
    {
        public bool ContieneMayusculas(string contra)
        {
            foreach (char c in contra)
            {
                if (char.IsUpper(c))
                    return true;
            }

            return false;
        }
    }
}
