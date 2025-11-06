using Datos.Conecction;
using Datos.DTOs_Stock;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Od_Stock
{
    public class Od_ReporteComprasPorProveedor : Ejeconsultas_Stock
    {
        public List<ReporteComprasPorProveedorDTO> ObtenerReporteComprasPorProveedor(int idProveedor, DateTime? fechaDesde = null, DateTime? fechaHasta = null)
        {
            try
            {
                string nombreSP = "sp_ReporteComprasPorProveedor";

                // Parámetros del procedimiento almacenado
                List<SqlParameter> parametros = new List<SqlParameter>
                {
                    new SqlParameter("@id_proveedor", SqlDbType.Int) { Value = idProveedor },
                    new SqlParameter("@fecha_desde", SqlDbType.Date) { Value = (object)fechaDesde ?? DBNull.Value },
                    new SqlParameter("@fecha_hasta", SqlDbType.Date) { Value = (object)fechaHasta ?? DBNull.Value }
                };

                SqlParameter[] sqlParam = parametros.ToArray();

                // Ejecutar el SP y obtener el DataTable
                DataTable dt = EjecConsultas(nombreSP, sqlParam);

                // Procesar el resultado y devolver una lista de DTOs
                List<ReporteComprasPorProveedorDTO> reporteCompras = new List<ReporteComprasPorProveedorDTO>();
                foreach (DataRow row in dt.Rows)
                {
                    reporteCompras.Add(new ReporteComprasPorProveedorDTO
                    {
                        IdProveedor = Convert.ToInt32(row["id_proveedor"]),
                        Proveedor = row["proveedor"].ToString(),
                        IdProducto = Convert.ToInt32(row["id_producto"]),
                        NombreProducto = row["nombre_producto"].ToString(),
                        PrecioCompra = Convert.ToDecimal(row["precio_compra"]),
                        CantidadComprada = Convert.ToInt32(row["cantidad_comprada"]),
                        TotalCompra = Convert.ToDecimal(row["total_compra"]),
                        FechaCompra = Convert.ToDateTime(row["fecha_compra"])
                    });
                }

                return reporteCompras;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al generar el reporte de compras por proveedor: " + ex.Message);
            }
        }
    }
}
