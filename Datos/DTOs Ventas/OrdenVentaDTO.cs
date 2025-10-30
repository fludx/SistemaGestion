using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.DTOs_Stock
{
    public class OrdenVentaDTO
    {
        public int IdCliente { get; set; }
        public DateTime FechaVenta { get; set; }
        public string MetodoPago { get; set; }
        public decimal Total { get; set; }
        public string Observaciones { get; set; }
    }
}

