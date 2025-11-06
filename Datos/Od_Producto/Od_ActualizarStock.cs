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
    public class Od_ActualizarStock : Ejeconsultas_Stock
    {
        public bool ActualizarStock(ActualizarStockDTO stockDTO)
        {
            try
            {
                string nombreSP = "sp_ActualizarStock";

                // Parámetros del procedimiento almacenado
                List<SqlParameter> parametros = new List<SqlParameter>
                {
                    new SqlParameter("@id_producto", SqlDbType.Int) { Value = stockDTO.IdProducto },
                    new SqlParameter("@cantidad", SqlDbType.Int) { Value = stockDTO.Cantidad },
                    new SqlParameter("@tipo_movimiento", SqlDbType.VarChar, 50) { Value = (object)stockDTO.TipoMovimiento ?? DBNull.Value },
                    new SqlParameter("@observacion", SqlDbType.VarChar, 255) { Value = (object)stockDTO.Observacion ?? DBNull.Value }
                };

                SqlParameter[] sqlParam = parametros.ToArray();

                // Ejecutar el SP
                DataTable dt = EjecConsultas(nombreSP, sqlParam);

                // Si devuelve filas, se considera exitoso
                return dt.Rows.Count > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el stock del producto: " + ex.Message);
            }
        }
    }
}
