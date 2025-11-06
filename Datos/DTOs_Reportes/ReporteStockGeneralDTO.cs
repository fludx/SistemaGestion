using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.DTOs_Stock
{
    public class ReporteStockGeneralDTO
    {
        public int IdProducto { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public int StockTotal { get; set; }
        public int StockMinimo { get; set; }
        public int PuntoReposicion { get; set; }
    }
}
