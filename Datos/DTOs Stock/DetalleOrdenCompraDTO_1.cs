﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.DTOs_Stock
{
    public class DetalleOrdenCompraDTO_1
    {
        public int IdOrdenCompra { get; set; }
        public int IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public string Lote { get; set; }
        public DateTime? Vencimiento { get; set; }
        public int Cantidad { get; set; }
        public decimal? PrecioUnitario { get; set; }
    }
}
