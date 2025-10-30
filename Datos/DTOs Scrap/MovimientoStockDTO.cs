using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.DTOs_Stock
{
    public class MovimientoStockDTO
    {
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public string TipoMovimiento { get; set; }
        public string Motivo { get; set; }
        public DateTime FechaMovimiento { get; set; }
    }
}

