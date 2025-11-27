using System;

namespace Datos.DTOs_Stock
{
    public class ProductoBuscarDTO
    {
        public int IdProducto { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Marca { get; set; }
        public string Categoria { get; set; }
        public decimal PrecioCompra { get; set; }
        public decimal PrecioVenta { get; set; }

        // Stocks y límites
        public int StockActual { get; set; }
        public int StockMinimo { get; set; }
        public int StockIdeal { get; set; }
        public int StockMaximo { get; set; }

        // Información por lote/vencimiento (opcional)
        public string Lote { get; set; }
        public DateTime? FechaVencimiento { get; set; }

        // Tipo de stock: 'Existencia' o 'JIT'
        public string TipoStock { get; set; }

        public bool Activo { get; set; }
    }
}