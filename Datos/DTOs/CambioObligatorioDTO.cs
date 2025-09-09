using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.DTOs
{
    public class CambioObligatorioDTO
    {
        public int Id_Usuario { get; set; }
        public string Contrasena { get; set; }
        public bool CambioObligatorio { get; set; }
    }
}
