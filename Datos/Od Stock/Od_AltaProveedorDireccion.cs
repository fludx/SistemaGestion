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
    public class Od_AltaProveedorDireccion : Ejeconsultas_Stock
    {
        public bool AltaProveedorDireccion(ProveedorDireccionDTO direccion)
        {
            try
            {
                string nombreSP = "sp_AltaProveedorDireccion";

                // Parámetros del procedimiento almacenado
                List<SqlParameter> parametros = new List<SqlParameter>
                {
                    new SqlParameter("@id_proveedor", SqlDbType.Int) { Value = direccion.IdProveedor },
                    new SqlParameter("@direccion", SqlDbType.NVarChar, 250) { Value = (object)direccion.Direccion ?? DBNull.Value },
                    new SqlParameter("@localidad", SqlDbType.NVarChar, 100) { Value = (object)direccion.Localidad ?? DBNull.Value },
                    new SqlParameter("@provincia", SqlDbType.NVarChar, 100) { Value = (object)direccion.Provincia ?? DBNull.Value },
                    new SqlParameter("@codigo_postal", SqlDbType.NVarChar, 20) { Value = (object)direccion.CodigoPostal ?? DBNull.Value },
                    new SqlParameter("@pais", SqlDbType.NVarChar, 100) { Value = (object)direccion.Pais ?? DBNull.Value }
                };

                SqlParameter[] sqlParam = parametros.ToArray();

                // Ejecutar el SP
                DataTable dt = EjecConsultas(nombreSP, sqlParam);

                // Retorna true si se insertó correctamente
                return dt.Rows.Count > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al dar de alta dirección de proveedor: " + ex.Message);
            }
        }
    }
}
