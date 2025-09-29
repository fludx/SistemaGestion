using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.DROs_Stock
{
    public class Reportes_DTOs
    {
        // sp_ReporteComprasPorProducto
        public class ReporteComprasPorProductoDTO
        {
            public string Nombre { get; set; }
            public int TotalComprado { get; set; }
            public decimal TotalGastado { get; set; }
        }

        // sp_ReporteComprasPorProveedor
        public class ReporteComprasPorProveedorDTO
        {
            public string NombreRazonSocial { get; set; }
            public int TotalUnidades { get; set; }
            public decimal TotalGastado { get; set; }
        }
    }
}
