using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.DTOs_Stock
{
    public class ScrapDTO
    {
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public string Motivo { get; set; }
        public DateTime FechaScrap { get; set; }
    }
}

