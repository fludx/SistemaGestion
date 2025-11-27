using System;

namespace Datos.DTOs_Stock
{
    public class ProveedorDeProductoDTO
    {
        public int IdProveedor { get; set; }

        
        public string Codigo { get; set; }

        // El SP/OD usa 'codigo' o 'codigo_proveedor' según variantes; expongo ambos.
        public string CodigoProveedor
        {
            get => Codigo;
            set => Codigo = value;
        }

        public string RazonSocial { get; set; }
        public string Email { get; set; }

        // Propiedades adicionales que consulta Od_ProveedoresDeProducto
        public string FormasPago { get; set; }
        public string TiemposEntrega { get; set; }
        public string Descuentos { get; set; }
    }
}

