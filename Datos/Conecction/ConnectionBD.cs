using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Datos.Conecction
{
    public class ConnectionBD
    {
        // En esta variable van a indicar el nombre del servidor que les arroja el SQL Server
        private static string host_name = "(local)";

        private static string cadenaConexion = "Data Source=" + host_name + ";Initial Catalog=BD_GESTION;Integrated Security=True;";
        /* NOMBRE DE LA BASE DE DATOS ES BD_GESTION */
        public static SqlConnection ObtenerConexion()
        {
            return new SqlConnection(cadenaConexion);
        }
    }
}
