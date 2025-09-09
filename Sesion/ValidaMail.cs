using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
namespace Sesion
{
    public static class ValidaMail 
    {
        public static bool Valid(string Correo)
        {
            String validacion;
            validacion = @"^(?("")(""[^""]+?""@)|(([0-9a-zA-Z]((\.|[-!#$%&'*+/=?^_`{|}~\w])*)(?<=[0-9a-zA-Z])@)))" +
                 @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-0-9a-zA-Z]*\.)+[a-zA-Z]{2,}))$";
            if (Regex.IsMatch(Correo, validacion))
            {
                if (Regex.Replace(Correo, validacion, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}