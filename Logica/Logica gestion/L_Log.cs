using Datos;
using Sesion;
using System.Collections.Generic;

namespace Logica
{
    public class L_Logs
    {
        private readonly D_Logs datos = new D_Logs();

        public List<Log> ListarLogs()
        {
            return datos.ListarLogs();
        }

        public void InsertarLog(string usuario, string accion)
        {
            Log log = new Log
            {
                Usuario = usuario,
                Accion = accion,
                Fecha = System.DateTime.Now
            };

            datos.InsertarLog(SesionUsuario.Usuario, "Inicio de sesión");

        }
    }
}
