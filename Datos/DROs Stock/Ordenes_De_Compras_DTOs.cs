using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.DROs_Stock
{
    public class Ordenes_De_Compras_DTOs
    {

        // sp_ConsultarOrdenesCompra
        public class OrdenCompraConsultaDTO
        {
            public int OrdenID { get; set; }
            public DateTime Fecha { get; set; }
            public string Estado { get; set; }
            public string NombreRazonSocial { get; set; }
        }

        // sp_ConsultarDetalleOrdenCompra
        public class DetalleOrdenCompraDTO
        {
            public int ProductoID { get; set; }
            public string Nombre { get; set; }
            public int Cantidad { get; set; }
            public decimal PrecioCompra { get; set; }
        }
    }
}
