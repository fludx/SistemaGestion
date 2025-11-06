using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.DROs_Stock
{
    public class Proveedores_DTOs
    {
        // sp_ConsultarProveedores
        public class ProveedorConsultaDTO
        {
            public int ProveedorID { get; set; }
            public string Codigo { get; set; }
            public string NombreRazonSocial { get; set; }
            public string CUIT { get; set; }
            public string Email { get; set; }
            public string FormaPago { get; set; }
            public int TiempoEntrega { get; set; }
            public decimal Descuento { get; set; }
        }

        // sp_ProductosDeProveedor
        public class ProductosDeProveedorDTO
        {
            public int ProductoID { get; set; }
            public string Nombre { get; set; }
            public decimal PrecioCompra { get; set; }
        }

        // sp_ProveedoresDeProducto
        public class ProveedoresDeProductoDTO
        {
            public int ProveedorID { get; set; }
            public string NombreRazonSocial { get; set; }
            public decimal PrecioCompra { get; set; }
        }
    }
}
