csharp Negocio\N_Ventas.cs
using System;
using System.Collections.Generic;
using Datos.DTOs_Stock;
using Datos.Od_Stock;

namespace Negocio
{
    public class N_Ventas
    {
        private readonly Od_CrearOrdenVenta _odCrearVenta = new Od_CrearOrdenVenta();

        /// <summary>
        /// Crea la orden de venta (cabecera). Devuelve BusinessResult con Success=true si se creó.
        /// Nota: la persistencia de detalles debe implementarse si existe un OD para ello.
        /// </summary>
        public BusinessResult CrearOrdenVenta(OrdenVentaDTO venta)
        {
            var res = new BusinessResult();
            if (venta == null)
            {
                res.AddError("Datos de la venta inválidos.");
                return res;
            }

            if (venta.IdCliente <= 0)
            {
                res.AddError("Cliente inválido.");
                return res;
            }

            if (venta.Total <= 0m)
            {
                res.AddError("El total debe ser mayor a cero.");
                return res;
            }

            try
            {
                bool ok = _odCrearVenta.CrearOrdenVenta(venta);
                if (!ok) res.AddError("No se pudo crear la orden de venta.");
                return res;
            }
            catch (Exception ex)
            {
                res.AddError("Error creando orden de venta: " + ex.Message);
                return res;
            }
        }
    }
}