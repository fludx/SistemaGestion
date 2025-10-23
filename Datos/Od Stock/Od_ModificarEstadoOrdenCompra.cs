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
    public class Od_ModificarEstadoOrdenCompra : Ejeconsultas_Stock
    {
        public bool ModificarEstadoOrdenCompra(ModificarEstadoOrdenCompraDTO dto)
        {
            try
            {
                string nombreSP = "sp_ModificarEstadoOrdenCompra";

                // Parámetros para el procedimiento almacenado
                List<SqlParameter> parametros = new List<SqlParameter>
                {
                    new SqlParameter("@id_orden_compra", SqlDbType.Int) { Value = dto.IdOrdenCompra },
                    new SqlParameter("@estado", SqlDbType.NVarChar, 50) { Value = dto.Estado }
                };

                SqlParameter[] sqlParam = parametros.ToArray();

                // Ejecutar el SP
                DataTable dt = EjecConsultas(nombreSP, sqlParam);

                // Retornar true si se actualizó correctamente
                return dt.Rows.Count > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al modificar el estado de la orden de compra: " + ex.Message);
            }
        }
    }
}