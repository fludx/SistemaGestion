using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.DTOs_Stock
{
    public class RecepcionCompraRegistrarDTO
    {
        public int IdOrdenCompra { get; set; }
        public DateTime FechaRecepcion { get; set; }
        public string NumeroRemito { get; set; }
        public string Observaciones { get; set; }
    }
}

