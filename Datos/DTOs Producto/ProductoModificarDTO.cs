using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.DTOs_Stock
{
    public class ProductoModificarDTO
    {
        public int IdProducto { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Marca { get; set; }
        public string Descripcion { get; set; }
        public decimal PrecioCompra { get; set; }
        public decimal PrecioVenta { get; set; }
        public int StockMinimo { get; set; }
        public int StockIdeal { get; set; }
        public int StockMaximo { get; set; }
        public int IdCategoria { get; set; }
        public bool Activo { get; set; }
    }
}

