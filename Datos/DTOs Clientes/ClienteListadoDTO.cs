using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.DTOs_Stock
{
    public class ClienteListadoDTO
    {
        public int IdCliente { get; set; }
        public string Codigo { get; set; }
        public string RazonSocial { get; set; }
        public string Email { get; set; }
        public string FormasPago { get; set; }
        public string Descuentos { get; set; }
        public decimal LimiteCredito { get; set; }
    }
}

