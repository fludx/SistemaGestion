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
    public class Od_ConsultarOrdenesCompra : Ejeconsultas_Stock
    {
        public List<OrdenCompraDTO> ConsultarOrdenesCompra(int? idProveedor = null, DateTime? fechaDesde = null, DateTime? fechaHasta = null, string estado = null)
        {
            try
            {
                string nombreSP = "sp_ConsultarOrdenesCompra";

                // Parámetros del procedimiento almacenado
                List<SqlParameter> parametros = new List<SqlParameter>
                {
                    new SqlParameter("@id_proveedor", SqlDbType.Int) { Value = (object)idProveedor ?? DBNull.Value },
                    new SqlParameter("@fecha_desde", SqlDbType.Date) { Value = (object)fechaDesde ?? DBNull.Value },
                    new SqlParameter("@fecha_hasta", SqlDbType.Date) { Value = (object)fechaHasta ?? DBNull.Value },
                    new SqlParameter("@estado", SqlDbType.NVarChar, 50) { Value = (object)estado ?? DBNull.Value }
                };

                SqlParameter[] sqlParam = parametros.ToArray();

                // Ejecutar el SP y obtener el DataTable
                DataTable dt = EjecConsultas(nombreSP, sqlParam);

                // Procesar el resultado y devolver una lista de DTOs
                List<OrdenCompraDTO> ordenesCompra = new List<OrdenCompraDTO>();
                foreach (DataRow row in dt.Rows)
                {
                    ordenesCompra.Add(new OrdenCompraDTO
                    {
                        IdOrdenCompra = Convert.ToInt32(row["id_orden_compra"]),
                        IdProveedor = Convert.ToInt32(row["id_proveedor"]),
                        ProveedorNombre = row["proveedor_nombre"].ToString(),
                        Fecha = Convert.ToDateTime(row["fecha"]),
                        Estado = row["estado"].ToString(),
                        Observaciones = row["observaciones"].ToString()
                    });
                }

                return ordenesCompra;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar las órdenes de compra: " + ex.Message);
            }
        }
    }
}
