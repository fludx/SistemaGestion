using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.DTOs_Stock;
using Datos.Od_Stock;


namespace Negocio
{
    public class N_Proveedores
    {
        private readonly Od_AltaProveedor odAlta = new Od_AltaProveedor();
        private readonly Od_ModificarProveedor odMod = new Od_ModificarProveedor();
        private readonly Od_EliminarProveedor odDel = new Od_EliminarProveedor();
        private readonly Od_ListarProveedores odList = new Od_ListarProveedores();
        private readonly Od_AltaProveedorContacto odContacto = new Od_AltaProveedorContacto();
        private readonly Od_AltaProveedorDireccion odDireccion = new Od_AltaProveedorDireccion();
        private readonly Od_ProductosDeProveedor odProdDeProv = new Od_ProductosDeProveedor();
        private readonly Od_ProveedoresDeProducto odProvDeProd = new Od_ProveedoresDeProducto();
        private readonly Od_RelacionarProductoProveedor odRelacion = new Od_RelacionarProductoProveedor();

        public BusinessResult CrearProveedor(ProveedorDTO proveedor)
        {
            var res = new BusinessResult();
            if (proveedor == null) { res.AddError("Proveedor inválido."); return res; }
            if (string.IsNullOrWhiteSpace(proveedor.RazonSocial)) res.AddError("Razón social obligatoria.");
            if (!res.Success) return res;

            try
            {
                bool ok = odAlta.AltaProveedor(proveedor);
                if (!ok) res.AddError("No se pudo dar de alta el proveedor.");
                return res;
            }
            catch (Exception ex)
            {
                res.AddError("Error creando proveedor: " + ex.Message);
                return res;
            }
        }

        public BusinessResult ModificarProveedor(ProveedorModificarDTO proveedor)
        {
            var res = new BusinessResult();
            if (proveedor == null) { res.AddError("Proveedor inválido."); return res; }
            if (string.IsNullOrWhiteSpace(proveedor.RazonSocial)) res.AddError("Razón social obligatoria.");
            if (!res.Success) return res;

            try
            {
                bool ok = odMod.ModificarProveedor(proveedor);
                if (!ok) res.AddError("No se pudo modificar el proveedor.");
                return res;
            }
            catch (Exception ex)
            {
                res.AddError("Error modificando proveedor: " + ex.Message);
                return res;
            }
        }

        public BusinessResult EliminarProveedor(int idProveedor)
        {
            var res = new BusinessResult();
            if (idProveedor <= 0) { res.AddError("Id proveedor inválido."); return res; }
            try
            {
                var dto = new ProveedorEliminarDTO { IdProveedor = idProveedor };
                bool ok = odDel.EliminarProveedor(dto);
                if (!ok) res.AddError("No se pudo eliminar el proveedor.");
                return res;
            }
            catch (Exception ex)
            {
                res.AddError("Error eliminando proveedor: " + ex.Message);
                return res;
            }
        }

        public BusinessResult<List<ProveedorListadoDTO>> ListarProveedores()
        {
            var res = new BusinessResult<List<ProveedorListadoDTO>>();
            try
            {
                res.Data = odList.ListarProveedores();
                return res;
            }
            catch (Exception ex)
            {
                res.AddError("Error listando proveedores: " + ex.Message);
                return res;
            }
        }

        public BusinessResult AgregarContacto(ProveedorContactoDTO contacto)
        {
            var res = new BusinessResult();
            if (contacto == null) { res.AddError("Contacto inválido."); return res; }
            try
            {
                bool ok = odContacto.AltaProveedorContacto(contacto);
                if (!ok) res.AddError("No se pudo guardar el contacto.");
                return res;
            }
            catch (Exception ex)
            {
                res.AddError("Error agregando contacto: " + ex.Message);
                return res;
            }
        }

        public BusinessResult AgregarDireccion(ProveedorDireccionDTO direccion)
        {
            var res = new BusinessResult();
            if (direccion == null) { res.AddError("Dirección inválida."); return res; }
            try
            {
                bool ok = odDireccion.AltaProveedorDireccion(direccion);
                if (!ok) res.AddError("No se pudo guardar la dirección.");
                return res;
            }
            catch (Exception ex)
            {
                res.AddError("Error agregando dirección: " + ex.Message);
                return res;
            }
        }

        //public BusinessResult<List<ProductoListadoDTO>> ProductosDeProveedor(int idProveedor)
        //{
        //    var res = new BusinessResult<List<ProductoListadoDTO>>();
        //    try
        //    {
        //        res.Data = odProdDeProv.ConsultarProductosDeProveedor(idProveedor);
        //        return res;
        //    }
        //    catch (Exception ex)
        //    {
        //        res.AddError("Error consultando productos del proveedor: " + ex.Message);
        //        return res;
        //    }
        //}

        public BusinessResult<List<ProveedorDeProductoDTO>> ProveedoresDeProducto(int idProducto)
        {
            var res = new BusinessResult<List<ProveedorDeProductoDTO>>();
            try
            {
                res.Data = odProvDeProd.ConsultarProveedoresDeProducto(idProducto);
                return res;
            }
            catch (Exception ex)
            {
                res.AddError("Error consultando proveedores del producto: " + ex.Message);
                return res;
            }
        }

        public BusinessResult RelacionarProductoProveedor(RelacionProductoProveedorDTO relacion)
        {
            var res = new BusinessResult();
            if (relacion == null) { res.AddError("Datos inválidos."); return res; }
            try
            {
                bool ok = odRelacion.RelacionarProductoProveedor(relacion);
                if (!ok) res.AddError("No se pudo relacionar producto y proveedor.");
                return res;
            }
            catch (Exception ex)
            {
                res.AddError("Error relacionando producto-proveedor: " + ex.Message);
                return res;
            }
        }
    }
}
