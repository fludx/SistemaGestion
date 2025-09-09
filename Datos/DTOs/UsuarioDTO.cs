using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.DTOs
{
    public class UsuarioDTO
    {
        public int Id_Usuario { get; set; }
        public int Id_Persona { get; set; }
        public string Usuario { get; set; }
        public string Contrasena { get; set; }
        public bool Bloqueado { get; set; }
        public DateTime? Fecha_Bloqueo { get; set; }
        public int CambioContra { get; set; }
        public DateTime? FechaCambioContra { get; set; }
        public int Id_Rol { get; set; }
    }
}
