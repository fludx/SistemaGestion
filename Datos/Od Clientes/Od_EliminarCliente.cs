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
    public class Od_EliminarCliente : Ejeconsultas_Stock
    {
        public bool EliminarCliente(ClienteEliminarDTO cliente)
        {
            try
            {
                string nombreSP = "sp_EliminarCliente";

                // Parámetros del SP
                List<SqlParameter> parametros = new List<SqlParameter>
                {
                    new SqlParameter("@id_cliente", SqlDbType.Int) { Value = cliente.IdCliente }
                };

                SqlParameter[] sqlParam = parametros.ToArray();

                // Ejecutar el procedimiento almacenado
                DataTable dt = EjecConsultas(nombreSP, sqlParam);

                // Si devuelve filas, consideramos la operación exitosa
                return dt.Rows.Count > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el cliente: " + ex.Message);
            }
        }
    }
}
