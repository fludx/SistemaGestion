using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.DTOs_Stock;
using Datos.Od_Stock;

namespace Negocio
{
    public class N_Productos
    {
        private readonly Od_AltaProducto odAlta = new Od_AltaProducto();
        private readonly Od_ModificarProducto odMod = new Od_ModificarProducto();
        private readonly Od_EliminarProducto odDel = new Od_EliminarProducto();
        private readonly Od_ListarProductos odList = new Od_ListarProductos();
        private readonly Od_BuscarProducto odBus = new Od_BuscarProducto();
        private readonly Od_ActualizarStock odActualizarStock = new Od_ActualizarStock();
        private readonly Od_Categorias odCategorias = new Od_Categorias(); // <-- añadido

        // Alta de producto (validaciones de negocio)
        public BusinessResult CrearProducto(ProductoDTO producto)
        {
            var res = new BusinessResult();
            if (producto == null)
            {
                res.AddError("Producto inválido.");
                return res;
            }

            if (string.IsNullOrWhiteSpace(producto.Nombre))
                res.AddError("El nombre del producto es obligatorio.");

            if (string.IsNullOrWhiteSpace(producto.Codigo))
                res.AddError("El código del producto es obligatorio.");

            if (producto.PrecioCompra < 0)
                res.AddError("Precio de compra inválido.");

            if (producto.PrecioVenta < 0)
                res.AddError("Precio de venta inválido.");

            if (producto.StockMinimo < 0 || producto.StockIdeal < 0 || producto.StockMaximo < 0)
                res.AddError("Los valores de stock no pueden ser negativos.");

            // Validación extra: id_categoria debe ser válido y existir en BD
            if (producto.IdCategoria <= 0)
                res.AddError("La categoría no es válida. Seleccione una categoría existente.");
            else if (!odCategorias.ExisteCategoria(producto.IdCategoria))
                res.AddError("La categoría indicada no existe en la base de datos.");

            if (!res.Success) return res;

            try
            {
                bool ok = odAlta.AltaProducto(producto);
                if (!ok) res.AddError("No se pudo dar de alta el producto en la base.");
                return res;
            }
            catch (Exception ex)
            {
                res.AddError("Error creando producto: " + ex.Message);
                return res;
            }
        }

        // Modificar producto
        public BusinessResult ModificarProducto(ProductoModificarDTO producto)
        {
            var res = new BusinessResult();
            if (producto == null) { res.AddError("Producto inválido."); return res; }
            if (string.IsNullOrWhiteSpace(producto.Nombre)) res.AddError("El nombre del producto es obligatorio.");
            if (!res.Success) return res;

            try
            {
                bool ok = odMod.ModificarProducto(producto);
                if (!ok) res.AddError("No se pudo modificar el producto.");
                return res;
            }
            catch (Exception ex)
            {
                res.AddError("Error modificando producto: " + ex.Message);
                return res;
            }
        }

        // Eliminar (baja)
        public BusinessResult EliminarProducto(int idProducto)
        {
            var res = new BusinessResult();
            if (idProducto <= 0) { res.AddError("Id de producto inválido."); return res; }

            try
            {
                var dto = new ProductoEliminarDTO { IdProducto = idProducto };
                bool ok = odDel.EliminarProducto(dto);
                if (!ok) res.AddError("No se pudo eliminar el producto.");
                return res;
            }
            catch (Exception ex)
            {
                res.AddError("Error eliminando producto: " + ex.Message);
                return res;
            }
        }

        // Listar productos (filtros opcionales)
        public BusinessResult<List<ProductoListadoDTO>> ListarProductos(int? idCategoria = null, bool? activo = null)
        {
            var res = new BusinessResult<List<ProductoListadoDTO>>();
            try
            {
                var lista = odList.ListarProductos(idCategoria, activo);
                res.Data = lista;
                return res;
            }
            catch (Exception ex)
            {
                res.AddError("Error al listar productos: " + ex.Message);
                return res;
            }
        }

        // Buscar por codigo/nombre/id
        public BusinessResult<List<ProductoBuscarDTO>> BuscarProducto(string codigo = null, string nombre = null, int? idProducto = null)
        {
            var res = new BusinessResult<List<ProductoBuscarDTO>>();
            try
            {
                var lista = odBus.BuscarProducto(codigo, nombre, idProducto);
                res.Data = lista;
                return res;
            }
            catch (Exception ex)
            {
                res.AddError("Error al buscar producto: " + ex.Message);
                return res;
            }
        }

        // Actualizar stock (ej: ingreso por compra, egreso por venta)
        public BusinessResult ActualizarStock(ActualizarStockDTO stockDto)
        {
            var res = new BusinessResult();
            if (stockDto == null) { res.AddError("Datos de stock inválidos."); return res; }
            if (stockDto.Cantidad == 0) { res.AddError("La cantidad debe ser distinta de cero."); return res; }

            try
            {
                bool ok = odActualizarStock.ActualizarStock(stockDto);
                if (!ok) res.AddError("No se pudo actualizar el stock.");
                return res;
            }
            catch (Exception ex)
            {
                res.AddError("Error actualizando stock: " + ex.Message);
                return res;
            }
        }
    }
}
