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
    public class Od_AltaProveedorContacto : Ejeconsultas_Stock
    {
        public bool AltaProveedorContacto(ProveedorContactoDTO contacto)
        {
            try
            {
                string nombreSP = "sp_AltaProveedorContacto";

                // Parámetros para el procedimiento almacenado
                List<SqlParameter> parametros = new List<SqlParameter>
                {
                    new SqlParameter("@id_proveedor", SqlDbType.Int) { Value = contacto.IdProveedor },
                    new SqlParameter("@nombre_contacto", SqlDbType.NVarChar, 150) { Value = (object)contacto.NombreContacto ?? DBNull.Value },
                    new SqlParameter("@cargo", SqlDbType.NVarChar, 100) { Value = (object)contacto.Cargo ?? DBNull.Value },
                    new SqlParameter("@telefono", SqlDbType.NVarChar, 50) { Value = (object)contacto.Telefono ?? DBNull.Value },
                    new SqlParameter("@email", SqlDbType.NVarChar, 200) { Value = (object)contacto.Email ?? DBNull.Value }
                };

                SqlParameter[] sqlParam = parametros.ToArray();

                // Ejecutar el SP
                DataTable dt = EjecConsultas(nombreSP, sqlParam);

                // Retorna true si se insertó correctamente
                return dt.Rows.Count > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al dar de alta contacto de proveedor: " + ex.Message);
            }
        }
    }
}
