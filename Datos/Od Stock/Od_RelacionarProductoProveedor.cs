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
    public class Od_RelacionarProductoProveedor : Ejeconsultas_Stock
    {
        public bool RelacionarProductoProveedor(RelacionProductoProveedorDTO relacion)
        {
            try
            {
                string nombreSP = "sp_RelacionarProductoProveedor";

                // Parámetros del procedimiento almacenado
                List<SqlParameter> parametros = new List<SqlParameter>
                {
                    new SqlParameter("@id_producto", SqlDbType.Int) { Value = relacion.IdProducto },
                    new SqlParameter("@id_proveedor", SqlDbType.Int) { Value = relacion.IdProveedor }
                };

                SqlParameter[] sqlParam = parametros.ToArray();

                // Ejecutar el SP
                DataTable dt = EjecConsultas(nombreSP, sqlParam);

                // Si el procedimiento afectó filas, es exitoso
                return dt.Rows.Count > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al relacionar producto con proveedor: " + ex.Message);
            }
        }
    }
}
