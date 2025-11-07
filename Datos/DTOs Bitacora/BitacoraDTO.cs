using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.DTOs_Stock
{
    public class BitacoraDTO
    {
        public int IdUsuario { get; set; }
        public string Accion { get; set; }
        public string Modulo { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}