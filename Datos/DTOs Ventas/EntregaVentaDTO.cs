using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.DTOs_Stock
{
    public class EntregaVentaDTO
    {
        public int IdVenta { get; set; }
        public DateTime FechaEntrega { get; set; }
        public string NumeroRemito { get; set; }
        public string Observaciones { get; set; }
    }
}

