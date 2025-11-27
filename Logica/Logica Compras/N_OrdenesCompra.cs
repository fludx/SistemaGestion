using System;
using System.Collections.Generic;
using System.Data;
using Datos.Od_Stock;

namespace Negocio
{
    public class N_OrdenesCompra
    {
        private readonly Od_OrdenesCompra odOC = new Od_OrdenesCompra();

        public BusinessResult<int> CrearOrdenCompra(int idProveedor, DateTime fecha, string estado = "Pendiente", string observaciones = null)
        {
            var res = new BusinessResult<int>();
            try
            {
                int id = odOC.CrearOrdenCompra(idProveedor, fecha, estado, observaciones);
                res.Data = id;
                if (id <= 0) res.AddError("No se devolvió id de la orden creada.");
                return res;
            }
            catch (Exception ex)
            {
                res.AddError("Error creando orden: " + ex.Message);
                return res;
            }
        }

        public BusinessResult AgregarDetalle(int idOrdenCompra, int idProducto, string lote, DateTime? vencimiento, int cantidad, decimal? precioUnitario)
        {
            var res = new BusinessResult();
            try
            {
                bool ok = odOC.AgregarDetalleCompra(idOrdenCompra, idProducto, lote, vencimiento, cantidad, precioUnitario);
                if (!ok) res.AddError("No se pudo agregar detalle.");
                return res;
            }
            catch (Exception ex)
            {
                res.AddError("Error agregando detalle: " + ex.Message);
                return res;
            }
        }

        public BusinessResult<DataTable> ListarOrdenesPendientes()
        {
            var res = new BusinessResult<DataTable>();
            try
            {
                var dt = odOC.ListarOrdenesPendientes();
                res.Data = dt;
                return res;
            }
            catch (Exception ex)
            {
                res.AddError("Error listando ordenes: " + ex.Message);
                return res;
            }
        }

        public BusinessResult<DataTable> ObtenerDetalleOrden(int idOrden)
        {
            var res = new BusinessResult<DataTable>();
            try
            {
                var dt = odOC.ObtenerDetalleOrden(idOrden);
                res.Data = dt;
                return res;
            }
            catch (Exception ex)
            {
                res.AddError("Error obteniendo detalle: " + ex.Message);
                return res;
            }
        }

        public BusinessResult RegistrarRecepcion(int idOrden, string usuario = null)
        {
            var res = new BusinessResult();
            try
            {
                bool ok = odOC.RegistrarRecepcionCompra(idOrden, usuario);
                if (!ok) res.AddError("No se pudo registrar la recepción.");
                return res;
            }
            catch (Exception ex)
            {
                res.AddError("Error registrando recepción: " + ex.Message);
                return res;
            }
        }
    }
}