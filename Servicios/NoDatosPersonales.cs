//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Servicios
//{
//    public class NoDatosPersonales
//    {
//        public string VerificarDatosPersonalesEnCadena(string contraseña, List<string> datosPersonales)
//        {
//            if (string.IsNullOrEmpty(contraseña) || datosPersonales == null || datosPersonales.Count == 0)
//            {
//                return contraseña;
//            }

//            foreach (var dato in datosPersonales)
//            {
//                if (!string.IsNullOrWhiteSpace(dato) && contraseña.ToLower().Contains(dato.ToLower()))
//                {
//                    return $" La cadena no puede contener datos personales como \"{dato}\".";
//                }
//            }

//            return contraseña;
//        }
//    }
//}
