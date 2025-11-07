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
    public class Od_CrearOrdenCompra : Ejeconsultas_Stock
    {
        public bool CrearOrdenCompra(OrdenCompraCrearDTO orden)
        {
            try
            {
                string nombreSP = "sp_CrearOrdenCompra";

                // Parámetros del procedimiento almacenado
                List<SqlParameter> parametros = new List<SqlParameter>
                {
                    new SqlParameter("@id_proveedor", SqlDbType.Int) { Value = orden.IdProveedor },
                    new SqlParameter("@numero_orden", SqlDbType.NVarChar, 50) { Value = orden.NumeroOrden },
                    new SqlParameter("@fecha_orden", SqlDbType.Date) { Value = orden.FechaOrden },
                    new SqlParameter("@estado", SqlDbType.NVarChar, 50) { Value = (object)orden.Estado ?? DBNull.Value },
                    new SqlParameter("@monto_total", SqlDbType.Decimal) { Precision = 18, Scale = 2, Value = orden.MontoTotal }
                };

                SqlParameter[] sqlParam = parametros.ToArray();

                // Ejecutar el procedimiento
                DataTable dt = EjecConsultas(nombreSP, sqlParam);

                // Si devuelve filas (SCOPE_IDENTITY, por ejemplo), consideramos que fue exitoso
                return dt.Rows.Count > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear la orden de compra: " + ex.Message);
            }
        }
    }
}