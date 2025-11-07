using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.DTOs_Stock
{
    public class OrdenCompraDTO
    {
        public int IdOrdenCompra { get; set; }
        public int IdProveedor { get; set; }
        public string ProveedorNombre { get; set; }
        public DateTime Fecha { get; set; }
        public string Estado { get; set; }
        public string Observaciones { get; set; }
    }
}

