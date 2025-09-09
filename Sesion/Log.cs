using System;

namespace Sesion
{
    public class Log
    {
        public string Usuario { get; set; }
        public string Accion { get; set; }
        public DateTime Fecha { get; set; }

        public Log() { }

        public Log(string usuario, string accion, DateTime fecha)
        {
            Usuario = usuario;
            Accion = accion;
            Fecha = fecha;
        }

        public string ObtenerMensaje()
        {
            if (!string.IsNullOrEmpty(Usuario))
                return $"El usuario {Usuario} realizó la acción: {Accion}";
            else
                throw new Exception("El nombre de usuario no puede ser vacío.");
        }
    }
}
