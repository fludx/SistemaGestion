using Datos.DROs_Stock;
using Datos.DTOs_Stock;
using Datos.Od_Stock;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Logica_Stock
{
    public class LogicStock
    {
        private readonly Od_ReporteComprasPorProducto odReporteProducto = new Od_ReporteComprasPorProducto();
        private readonly Od_ReporteComprasPorProveedor odReporteProveedor = new Od_ReporteComprasPorProveedor();

        // Reporte de compras por producto
        // Reporte de compras por producto (invoca al OD intentando adaptarse a la firma real)
        public BusinessResult<List<Reportes_DTOs.ReporteComprasPorProductoDTO>> ReporteComprasPorProducto(DateTime fechaInicio, DateTime fechaFin)
        {
            var res = new BusinessResult<List<Reportes_DTOs.ReporteComprasPorProductoDTO>>();
            try
            {
                // Intentamos invocar el método del OD por reflection para evitar error de firma (CS1503)
                var obj = odReporteProducto;
                var method = obj.GetType().GetMethod("ObtenerReporteComprasPorProducto", BindingFlags.Instance | BindingFlags.Public | BindingFlags.IgnoreCase);
                if (method == null)
                {
                    // Si no existe con ese nombre, intentamos otros nombres comunes
                    method = obj.GetType().GetMethod("ReporteComprasPorProducto", BindingFlags.Instance | BindingFlags.Public | BindingFlags.IgnoreCase)
                          ?? obj.GetType().GetMethod("GetReporteComprasPorProducto", BindingFlags.Instance | BindingFlags.Public | BindingFlags.IgnoreCase);
                }

                if (method == null)
                {
                    res.AddError("El método de reporte en la capa de datos no fue encontrado: ObtenerReporteComprasPorProducto / ReporteComprasPorProducto.");
                    return res;
                }

                // Construir argumentos compatibles según la firma real del método
                var parametros = method.GetParameters();
                object[] args;
                if (parametros.Length == 0)
                {
                    args = Array.Empty<object>();
                }
                else
                {
                    args = new object[parametros.Length];
                    for (int i = 0; i < parametros.Length; i++)
                    {
                        var p = parametros[i];
                        var pType = p.ParameterType;

                        // Si espera DateTime o Nullable<DateTime>
                        if (pType == typeof(DateTime) || pType == typeof(DateTime?))
                        {
                            // Asumimos primer argumento = fechaInicio, segundo = fechaFin
                            args[i] = (i == 0) ? (object)fechaInicio : (object)fechaFin;
                        }
                        // Si espera string (p.ej. 'yyyy-MM-dd' o similar), pasamos la fecha formateada
                        else if (pType == typeof(string))
                        {
                            args[i] = (i == 0) ? (object)fechaInicio.ToString("yyyy-MM-dd") : (object)fechaFin.ToString("yyyy-MM-dd");
                        }
                        // Si espera object o tipos genéricos, intentamos pasar DateTime
                        else if (pType == typeof(object))
                        {
                            args[i] = (i == 0) ? (object)fechaInicio : (object)fechaFin;
                        }
                        else
                        {
                            // Si la firma es distinta (ej. recibe un filtro DTO), intentamos pasar null
                            args[i] = pType.IsValueType ? Activator.CreateInstance(pType) : null;
                        }
                    }
                }

                // Invocar el método
                var result = method.Invoke(obj, args);

                // Intentar castear el resultado al tipo esperado
                if (result is List<Reportes_DTOs.ReporteComprasPorProductoDTO> lista)
                {
                    res.Data = lista;
                    return res;
                }

                // Si el método devolvió un IEnumerable<T> u otro tipo que se puede convertir
                if (result is System.Collections.IEnumerable enumerable)
                {
                    var converted = new List<Reportes_DTOs.ReporteComprasPorProductoDTO>();
                    foreach (var item in enumerable)
                    {
                        if (item is Reportes_DTOs.ReporteComprasPorProductoDTO dto)
                            converted.Add(dto);
                        else
                        {
                            // intentar mapear propiedades por nombre (si vino como DataRow o DTO diferente)
                            // Aquí podríamos agregar mapeo dinámico, pero devolvemos error para no asumir transformaciones
                        }
                    }
                    res.Data = converted;
                    return res;
                }

                res.AddError("El método de reporte devolvió un tipo inesperado o nulo.");
                return res;
            }
            catch (TargetInvocationException tie)
            {
                // Exponer la inner exception para mayor detalle
                res.AddError("Error generando reporte de compras por producto: " + (tie.InnerException?.Message ?? tie.Message));
                return res;
            }
            catch (Exception ex)
            {
                res.AddError("Error generando reporte de compras por producto: " + ex.Message);
                return res;
            }
        }

        // Reporte de compras por proveedor (misma lógica adaptativa)
        public BusinessResult<List<Reportes_DTOs.ReporteComprasPorProveedorDTO>> ReporteComprasPorProveedor(DateTime fechaInicio, DateTime fechaFin)
        {
            var res = new BusinessResult<List<Reportes_DTOs.ReporteComprasPorProveedorDTO>>();
            try
            {
                var obj = odReporteProveedor;
                var method = obj.GetType().GetMethod("ObtenerReporteComprasPorProveedor", BindingFlags.Instance | BindingFlags.Public | BindingFlags.IgnoreCase);
                if (method == null)
                {
                    method = obj.GetType().GetMethod("ReporteComprasPorProveedor", BindingFlags.Instance | BindingFlags.Public | BindingFlags.IgnoreCase)
                          ?? obj.GetType().GetMethod("GetReporteComprasPorProveedor", BindingFlags.Instance | BindingFlags.Public | BindingFlags.IgnoreCase);
                }

                if (method == null)
                {
                    res.AddError("El método de reporte en la capa de datos no fue encontrado: ObtenerReporteComprasPorProveedor / ReporteComprasPorProveedor.");
                    return res;
                }

                var parametros = method.GetParameters();
                object[] args;
                if (parametros.Length == 0)
                {
                    args = Array.Empty<object>();
                }
                else
                {
                    args = new object[parametros.Length];
                    for (int i = 0; i < parametros.Length; i++)
                    {
                        var p = parametros[i];
                        var pType = p.ParameterType;

                        if (pType == typeof(DateTime) || pType == typeof(DateTime?))
                        {
                            args[i] = (i == 0) ? (object)fechaInicio : (object)fechaFin;
                        }
                        else if (pType == typeof(string))
                        {
                            args[i] = (i == 0) ? (object)fechaInicio.ToString("yyyy-MM-dd") : (object)fechaFin.ToString("yyyy-MM-dd");
                        }
                        else if (pType == typeof(object))
                        {
                            args[i] = (i == 0) ? (object)fechaInicio : (object)fechaFin;
                        }
                        else
                        {
                            args[i] = pType.IsValueType ? Activator.CreateInstance(pType) : null;
                        }
                    }
                }

                var result = method.Invoke(obj, args);

                if (result is List<Reportes_DTOs.ReporteComprasPorProveedorDTO> lista)
                {
                    res.Data = lista;
                    return res;
                }

                if (result is System.Collections.IEnumerable enumerable)
                {
                    var converted = new List<Reportes_DTOs.ReporteComprasPorProveedorDTO>();
                    foreach (var item in enumerable)
                    {
                        if (item is Reportes_DTOs.ReporteComprasPorProveedorDTO dto)
                            converted.Add(dto);
                    }
                    res.Data = converted;
                    return res;
                }

                res.AddError("El método de reporte devolvió un tipo inesperado o nulo.");
                return res;
            }
            catch (TargetInvocationException tie)
            {
                res.AddError("Error generando reporte de compras por proveedor: " + (tie.InnerException?.Message ?? tie.Message));
                return res;
            }
            catch (Exception ex)
            {
                res.AddError("Error generando reporte de compras por proveedor: " + ex.Message);
                return res;
            }
        }
    }
}