using System;

namespace Datos.DTOs_Stock
{
    public class ProductoVencimientoDTO
    {
        public int IdProducto { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Lote { get; set; }
        public DateTime? Vencimiento { get; set; }
        public int Cantidad { get; set; }
    }
}