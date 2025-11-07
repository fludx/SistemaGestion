using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.DTOs_Stock
{
    public class OrdenCompraCrearDTO
    {
        public int IdProveedor { get; set; }
        public string NumeroOrden { get; set; }
        public DateTime FechaOrden { get; set; }
        public string Estado { get; set; }
        public decimal MontoTotal { get; set; }
    }
}

