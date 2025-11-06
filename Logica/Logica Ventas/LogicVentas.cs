using Datos.DTOs_Stock;
using Datos.Od_Stock;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Logica_Ventas
{
    public class LogicVentas
    {
        private readonly Od_CrearOrdenCompra odCrearOrden = new Od_CrearOrdenCompra();
        private readonly Od_AgregarDetalleOrdenCompra odAgregarDetalle = new Od_AgregarDetalleOrdenCompra();
        private readonly Od_ConsultarOrdenesCompra odConsultarOrdenes = new Od_ConsultarOrdenesCompra();
        private readonly Od_ConsultarDetalleOrdenCompra odConsultarDetalles = new Od_ConsultarDetalleOrdenCompra();
        private readonly Od_ModificarEstadoOrdenCompra odModificarEstado = new Od_ModificarEstadoOrdenCompra();
        private readonly Od_RegistrarRecepcionCompra odRegistrarRecepcion = new Od_RegistrarRecepcionCompra();
        private readonly Od_DevolucionProveedor odDevolucion = new Od_DevolucionProveedor();
        private readonly Od_ReporteComprasPorProveedor odReporteProv = new Od_ReporteComprasPorProveedor();
        private readonly Od_ReporteComprasPorProducto odReporteProd = new Od_ReporteComprasPorProducto();

        // Crear orden con detalles (transaccional: creamos orden y agregamos detalles)
        public BusinessResult CrearOrdenCompra(OrdenCompraCrearDTO orden, List<DetalleOrdenCompraDTO> detalles)
        {
            var res = new BusinessResult();
            if (orden == null) { res.AddError("Orden inválida."); return res; }
            if (orden.IdProveedor <= 0) res.AddError("Proveedor inválido.");
            if (detalles == null || detalles.Count == 0) res.AddError("Debe agregar al menos un detalle.");

            if (!res.Success) return res;

            try
            {
                bool creada = odCrearOrden.CrearOrdenCompra(orden);
                if (!creada) { res.AddError("No se pudo crear la orden de compra."); return res; }

                foreach (var det in detalles)
                {
                    var detalleRes = odAgregarDetalle.AgregarDetalleCompra(det);
                    if (!detalleRes)
                        res.AddError($"No se pudo agregar el detalle para el producto {det.IdProducto}.");
                }

                return res;
            }
            catch (Exception ex)
            {
                res.AddError("Error creando orden de compra: " + ex.Message);
                return res;
            }
        }

        public BusinessResult<List<OrdenCompraDTO>> ConsultarOrdenesCompra()
        {
            var res = new BusinessResult<List<OrdenCompraDTO>>();
            try
            {
                res.Data = odConsultarOrdenes.ConsultarOrdenesCompra();
                return res;
            }
            catch (Exception ex)
            {
                res.AddError("Error consultando órdenes: " + ex.Message);
                return res;
            }
        }

        public List<DetalleOrdenCompraDTO_1> ConsultarDetalleOrdenCompra(int idOrdenCompra)
        {
            Od_ConsultarDetalleOrdenCompra od = new Od_ConsultarDetalleOrdenCompra();
            return od.ConsultarDetalleOrdenCompra(idOrdenCompra);
        }

        public BusinessResult CambiarEstadoOrden(int idOrden, string nuevoEstado)
        {
            var res = new BusinessResult();
            try
            {
                // Crear el DTO que el método espera
                var dto = new ModificarEstadoOrdenCompraDTO
                {
                    IdOrdenCompra = idOrden,
                    Estado = nuevoEstado
                };

                bool ok = odModificarEstado.ModificarEstadoOrdenCompra(dto);

                if (!ok)
                    res.AddError("No se pudo cambiar el estado de la orden.");

                return res;
            }
            catch (Exception ex)
            {
                res.AddError("Error cambiando estado: " + ex.Message);
                return res;
            }
        }

        public BusinessResult RegistrarRecepcion(RecepcionCompraRegistrarDTO recepcion)
        {
            var res = new BusinessResult();
            try
            {
                bool ok = odRegistrarRecepcion.RegistrarRecepcionCompra(recepcion);
                if (!ok) res.AddError("No se pudo registrar la recepción.");
                return res;
            }
            catch (Exception ex)
            {
                res.AddError("Error registrando recepción: " + ex.Message);
                return res;
            }
        }

        public BusinessResult RegistrarDevolucion(DevolucionProveedorDTO devolucion)
        {
            var res = new BusinessResult();
            try
            {
                bool ok = odDevolucion.RegistrarDevolucionProveedor(devolucion);
                if (!ok) res.AddError("No se pudo registrar la devolución al proveedor.");
                return res;
            }
            catch (Exception ex)
            {
                res.AddError("Error registrando devolución: " + ex.Message);
                return res;
            }
        }

        // Reportes
        public BusinessResult<List<ReporteComprasPorProveedorDTO>> ReporteComprasPorProveedor(int idProveedor, DateTime? desde = null, DateTime? hasta = null)
        {
            var res = new BusinessResult<List<ReporteComprasPorProveedorDTO>>();
            try
            {
                res.Data = odReporteProv.ObtenerReporteComprasPorProveedor(idProveedor, desde, hasta);
                return res;
            }
            catch (Exception ex)
            {
                res.AddError("Error generando reporte: " + ex.Message);
                return res;
            }
        }

        public BusinessResult<List<ReporteComprasPorProductoDTO>> ReporteComprasPorProducto(int idProducto, DateTime? desde = null, DateTime? hasta = null)
        {
            var res = new BusinessResult<List<ReporteComprasPorProductoDTO>>();
            try
            {
                res.Data = odReporteProd.ObtenerReporteComprasPorProducto(idProducto, desde, hasta);
                return res;
            }
            catch (Exception ex)
            {
                res.AddError("Error generando reporte: " + ex.Message);
                return res;
            }
        }
    }
}
