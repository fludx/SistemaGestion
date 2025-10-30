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
    public class Od_AltaProveedor : Ejeconsultas_Stock
    {
        public bool AltaProveedor(ProveedorDTO proveedor)
        {
            try
            {
                string nombreSP = "sp_AltaProveedor";

                // Parámetros del procedimiento almacenado
                List<SqlParameter> parametros = new List<SqlParameter>
                {
                    new SqlParameter("@codigo", SqlDbType.NVarChar, 50) { Value = proveedor.Codigo },
                    new SqlParameter("@razon_social", SqlDbType.NVarChar, 200) { Value = proveedor.RazonSocial },
                    new SqlParameter("@email", SqlDbType.NVarChar, 200) { Value = (object)proveedor.Email ?? DBNull.Value },
                    new SqlParameter("@formas_pago", SqlDbType.NVarChar, 200) { Value = (object)proveedor.FormasPago ?? DBNull.Value },
                    new SqlParameter("@tiempos_entrega", SqlDbType.NVarChar, 100) { Value = (object)proveedor.TiemposEntrega ?? DBNull.Value },
                    new SqlParameter("@descuentos", SqlDbType.NVarChar, 200) { Value = (object)proveedor.Descuentos ?? DBNull.Value }
                };

                SqlParameter[] sqlParam = parametros.ToArray();

                // Ejecutar el SP
                DataTable dt = EjecConsultas(nombreSP, sqlParam);

                // Si el SP devuelve filas (SCOPE_IDENTITY), se considera exitosa la inserción
                return dt.Rows.Count > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al dar de alta el proveedor: " + ex.Message);
            }
        }
    }
}
