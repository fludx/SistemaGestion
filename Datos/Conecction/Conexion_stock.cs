using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Conecction
{
    public class Conexion_stock
    {
        // En esta variable van a indicar el nombre del servidor que les arroja el SQL Server
        private static string host_name = "(local)";

        private static string cadenaConexion = "Data Source=" + host_name + ";Initial Catalog=BD_STOCK;Integrated Security=True;";
       
        public static SqlConnection GetConexion()
        {
            return new SqlConnection(cadenaConexion);
        }
    }
}
