using Datos.Conecction;
using Datos.DTOs_Stock;
using System;
using System.Data.SqlClient;

namespace Datos.Od_Stock
{
    public class Od_RelacionarProductoProveedor : Ejeconsultas_Stock
    {
        public bool RelacionarProductoProveedor(RelacionProductoProveedorDTO relacion)
        {
            try
            {
                string nombreSP = "sp_AsignarProductoAProveedor";

                SqlParameter[] sqlParam = new SqlParameter[]
                {
                    new SqlParameter("@id_proveedor", System.Data.SqlDbType.Int) { Value = relacion.IdProveedor },
                    new SqlParameter("@id_producto", System.Data.SqlDbType.Int) { Value = relacion.IdProducto }
                };

                // Ejecutar como non-query
                EjecConsultas(nombreSP, sqlParam, true);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al relacionar producto con proveedor: " + ex.Message);
            }
        }
    }
}
