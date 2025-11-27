using Datos.Conecction;
using Datos.DTOs_Stock;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Datos.Od_Stock
{
    public class Od_ActualizarStock : Ejeconsultas_Stock
    {
        public bool ActualizarStock(ActualizarStockDTO dto)
        {
            try
            {
                string nombreSP = "sp_ActualizarStock";

                List<SqlParameter> parametros = new List<SqlParameter>
                {
                    new SqlParameter("@id_producto", SqlDbType.Int) { Value = dto.IdProducto },
                    new SqlParameter("@lote", SqlDbType.NVarChar, 50) { Value = (object)dto.Lote ?? DBNull.Value },
                    new SqlParameter("@vencimiento", SqlDbType.Date) { Value = (object)dto.Vencimiento ?? DBNull.Value },
                    new SqlParameter("@cantidad", SqlDbType.Int) { Value = dto.Cantidad }
                };

                SqlParameter[] sqlParam = parametros.ToArray();

                // El SP realiza inserts; ejecutar como non-query
                EjecConsultas(nombreSP, sqlParam, true);

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el stock: " + ex.Message);
            }
        }
    }
}