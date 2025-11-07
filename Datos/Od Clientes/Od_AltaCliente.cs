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
    public class Od_AltaCliente : Ejeconsultas_Stock
    {
        public bool AltaCliente(ClienteDTO cliente)
        {
            try
            {
                string nombreSP = "sp_AltaCliente";

                // Parámetros del procedimiento almacenado
                List<SqlParameter> parametros = new List<SqlParameter>
                {
                    new SqlParameter("@codigo", SqlDbType.NVarChar, 50) { Value = cliente.Codigo },
                    new SqlParameter("@razon_social", SqlDbType.NVarChar, 200) { Value = cliente.RazonSocial },
                    new SqlParameter("@email", SqlDbType.NVarChar, 200) { Value = (object)cliente.Email ?? DBNull.Value },
                    new SqlParameter("@formas_pago", SqlDbType.NVarChar, 200) { Value = (object)cliente.FormasPago ?? DBNull.Value },
                    new SqlParameter("@descuentos", SqlDbType.NVarChar, 200) { Value = (object)cliente.Descuentos ?? DBNull.Value },
                    new SqlParameter("@limite_credito", SqlDbType.Decimal)
                    {
                        Precision = 18,
                        Scale = 2,
                        Value = cliente.LimiteCredito
                    }
                };

                SqlParameter[] sqlParam = parametros.ToArray();

                // Ejecutar el procedimiento
                DataTable dt = EjecConsultas(nombreSP, sqlParam);

                // Si devuelve filas (SCOPE_IDENTITY), consideramos exitosa la inserción
                return dt.Rows.Count > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al dar de alta el cliente: " + ex.Message);
            }
        }
    }
}
