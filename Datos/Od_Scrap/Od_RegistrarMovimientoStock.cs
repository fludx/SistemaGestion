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
    public class Od_RegistrarMovimientoStock : Ejeconsultas_Stock
    {
        public bool RegistrarMovimientoStock(MovimientoStockDTO movimiento)
        {
            try
            {
                string nombreSP = "sp_RegistrarMovimientoStock";

                // Parámetros del procedimiento almacenado
                List<SqlParameter> parametros = new List<SqlParameter>
                {
                    new SqlParameter("@id_producto", SqlDbType.Int) { Value = movimiento.IdProducto },
                    new SqlParameter("@cantidad", SqlDbType.Int) { Value = movimiento.Cantidad },
                    new SqlParameter("@tipo_movimiento", SqlDbType.NVarChar, 50) { Value = movimiento.TipoMovimiento },
                    new SqlParameter("@motivo", SqlDbType.NVarChar, 255) { Value = (object)movimiento.Motivo ?? DBNull.Value },
                    new SqlParameter("@fecha_movimiento", SqlDbType.DateTime2) { Value = movimiento.FechaMovimiento }
                };

                SqlParameter[] sqlParam = parametros.ToArray();

                // Ejecutar el SP
                DataTable dt = EjecConsultas(nombreSP, sqlParam);

                // Si devuelve filas, consideramos la operación exitosa
                return dt.Rows.Count > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al registrar el movimiento de stock: " + ex.Message);
            }
        }
    }
}
