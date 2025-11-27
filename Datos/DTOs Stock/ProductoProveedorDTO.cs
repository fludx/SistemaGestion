using System;

namespace Datos.DTOs_Stock
{
    public class ProductoProveedorDTO
    {
        public int IdProducto { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Marca { get; set; }
        public decimal PrecioCompra { get; set; }
        public decimal PrecioVenta { get; set; }
    }
}

