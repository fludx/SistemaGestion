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
    public class Od_DevolucionCliente : Ejeconsultas_Stock
    {
        public bool RegistrarDevolucionCliente(DevolucionClienteDTO devolucion)
        {
            try
            {
                string nombreSP = "sp_DevolucionCliente";

                // Lista de parámetros del SP
                List<SqlParameter> parametros = new List<SqlParameter>
                {
                    new SqlParameter("@id_cliente", SqlDbType.Int) { Value = devolucion.IdCliente },
                    new SqlParameter("@id_producto", SqlDbType.Int) { Value = devolucion.IdProducto },
                    new SqlParameter("@cantidad", SqlDbType.Int) { Value = devolucion.Cantidad },
                    new SqlParameter("@motivo", SqlDbType.NVarChar, 255) { Value = (object)devolucion.Motivo ?? DBNull.Value },
                    new SqlParameter("@fecha_devolucion", SqlDbType.Date) { Value = devolucion.FechaDevolucion }
                };

                SqlParameter[] sqlParam = parametros.ToArray();

                // Ejecutar el procedimiento almacenado
                DataTable dt = EjecConsultas(nombreSP, sqlParam);

                // Si devuelve filas (por ejemplo SCOPE_IDENTITY), consideramos la operación exitosa
                return dt.Rows.Count > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al registrar la devolución del cliente: " + ex.Message);
            }
        }
    }
}
