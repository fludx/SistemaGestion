using Datos.Conecction;
using System;
using System.Data.SqlClient;

namespace Datos.Od_Stock
{
    public class Od_DesasignarProductoProveedor : Ejeconsultas_Stock
    {
        public bool Desasignar(int idProveedor, int idProducto)
        {
            try
            {
                string nombreSP = "sp_DesasignarProductoAProveedor";
                SqlParameter[] sqlParam = new SqlParameter[]
                {
                    new SqlParameter("@id_proveedor", System.Data.SqlDbType.Int) { Value = idProveedor },
                    new SqlParameter("@id_producto", System.Data.SqlDbType.Int) { Value = idProducto }
                };
                EjecConsultas(nombreSP, sqlParam, true);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al desasignar producto-proveedor: " + ex.Message);
            }
        }
    }
}