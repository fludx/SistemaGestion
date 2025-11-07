using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.DTOs_Stock
{
    public class ReporteComprasPorProveedorDTO
    {
        public int IdProveedor { get; set; }
        public string Proveedor { get; set; }
        public int IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public decimal PrecioCompra { get; set; }
        public int CantidadComprada { get; set; }
        public decimal TotalCompra { get; set; }
        public DateTime FechaCompra { get; set; }
    }
}

