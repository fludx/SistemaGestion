using Datos.Conecction;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class D_ListarPersonas
    {
        public DataTable ListarPersonas()
        {
            DataTable tabla = new DataTable();

            try
            {
                using (SqlConnection conexion = ConnectionBD.ObtenerConexion())
                {
                    conexion.Open();

                    using (SqlCommand cmd = new SqlCommand("sp_ListarPersonas", conexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(tabla);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al listar personas: " + ex.Message);
                tabla = null;
            }

            return tabla;
        }
    }
}