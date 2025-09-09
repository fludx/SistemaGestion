//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Servicios
//{
//    public class NoRepContras
//    {
//        public string NoRepetirContras(string contraseña, List<string> contraseñas)
//        {
//            if (contraseñas == null || contraseñas.Count == 0)
//            {
//                return contraseña;
//            }

//            foreach (string contra in contraseñas)
//            {
//                if (!string.IsNullOrEmpty(contra) && contra == contraseña)
//                {
//                    return "No repetir contraseñas anteriores";
//                }
//            }
//            return contraseña;
//        }

//    }
//}
