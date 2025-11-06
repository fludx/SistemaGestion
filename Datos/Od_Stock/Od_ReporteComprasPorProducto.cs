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
    public class Od_ReporteComprasPorProducto : Ejeconsultas_Stock
    {
        public List<ReporteComprasPorProductoDTO> ObtenerReporteComprasPorProducto(int idProducto, DateTime? fechaDesde = null, DateTime? fechaHasta = null)
        {
            try
            {
                string nombreSP = "sp_ReporteComprasPorProducto";

                // Parámetros del procedimiento almacenado
                List<SqlParameter> parametros = new List<SqlParameter>
                {
                    new SqlParameter("@id_producto", SqlDbType.Int) { Value = idProducto },
                    new SqlParameter("@fecha_desde", SqlDbType.Date) { Value = (object)fechaDesde ?? DBNull.Value },
                    new SqlParameter("@fecha_hasta", SqlDbType.Date) { Value = (object)fechaHasta ?? DBNull.Value }
                };

                SqlParameter[] sqlParam = parametros.ToArray();

                // Ejecutar el SP y obtener el DataTable
                DataTable dt = EjecConsultas(nombreSP, sqlParam);

                // Procesar el resultado y devolver una lista de DTOs
                List<ReporteComprasPorProductoDTO> reporteCompras = new List<ReporteComprasPorProductoDTO>();
                foreach (DataRow row in dt.Rows)
                {
                    reporteCompras.Add(new ReporteComprasPorProductoDTO
                    {
                        IdProducto = Convert.ToInt32(row["id_producto"]),
                        Codigo = row["codigo"].ToString(),
                        NombreProducto = row["nombre_producto"].ToString(),
                        Proveedor = row["proveedor"].ToString(),
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
                throw new Exception("Error al generar el reporte de compras por producto: " + ex.Message);
            }
        }
    }
}
