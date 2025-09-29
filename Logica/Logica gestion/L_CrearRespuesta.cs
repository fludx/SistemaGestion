using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class L_CrearRespuesta
    {
        public static bool CrearRespuesta(int idusuario, int idpregunta, string respuesta, out string mensaje)
        {
            mensaje = null;
            try
            {
                return Datos.D_CrearRespuesta.CrearRespuesta(idusuario, idpregunta, respuesta, out mensaje);
            }
            catch (Exception ex)
            {
                mensaje = "Error inesperado: " + ex.Message;
                return false;
            }
        }
    }
}
