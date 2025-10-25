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
    public class Od_EliminarProducto : Ejeconsultas_Stock
    {
        public bool EliminarProducto(ProductoEliminarDTO producto)
        {
            try
            {
                string nombreSP = "sp_EliminarProducto";

                // Parámetros del SP
                List<SqlParameter> parametros = new List<SqlParameter>
                {
                    new SqlParameter("@id_producto", SqlDbType.Int) { Value = producto.IdProducto }
                };

                SqlParameter[] sqlParam = parametros.ToArray();

                // Ejecutar el SP
                DataTable dt = EjecConsultas(nombreSP, sqlParam);

                // Si devuelve filas, se considera que se ejecutó correctamente
                return dt.Rows.Count > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el producto: " + ex.Message);
            }
        }
    }
}
