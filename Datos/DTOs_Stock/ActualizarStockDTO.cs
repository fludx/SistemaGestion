using System;

namespace Datos.DTOs_Stock
{
    public class ActualizarStockDTO
    {
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public string Lote { get; set; }
        public DateTime? Vencimiento { get; set; }
        public string TipoMovimiento { get; set; } // 'Entrada' / 'Salida'
        public string Observacion { get; set; }
    }
}