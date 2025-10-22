using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.DROs_Stock
{// sp_StockPorLote
    public class Datos_DTOs
    {    
        public class StockPorLoteDTO
        {
            public string Lote { get; set; }
            public DateTime? FechaVencimiento { get; set; }
            public int Cantidad { get; set; }
            public string Ubicacion { get; set; }
        }

        // sp_ProductosPorDebajoStock
        public class ProductoDebajoStockDTO
        {
            public int ProductoID { get; set; }
            public string Nombre { get; set; }
            public int StockActual { get; set; }
            public int StockMinimo { get; set; }
            public int StockMaximo { get; set; }
        }

        // sp_ProductosProximosAVencer
        public class ProductoProximoAVencerDTO
        {
            public int ProductoID { get; set; }
            public string Nombre { get; set; }
            public string Lote { get; set; }
            public DateTime FechaVencimiento { get; set; }
            public int Cantidad { get; set; }
        }
    }

}

