using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.Conecction;


namespace Datos
{
   public class D_Traer_Genero
    {
        public int? ObtenerIdGenero(string genero)
        {
            int? idGenero = null;

            using (SqlConnection conexion = ConnectionBD.ObtenerConexion())
            {
                using (SqlCommand comando = new SqlCommand("sp_Traer_Genero", conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@Genero", genero);

                    try
                    {
                        conexion.Open();
                        SqlDataReader lector = comando.ExecuteReader();

                        if (lector.Read())
                        {
                            idGenero = lector.GetInt32(0);
                        }

                        lector.Close();
                    }
                    catch (Exception ex)
                    {
                        
                        Console.WriteLine("Error al traer el género: " + ex.Message);
                    }
                }
            }

            return idGenero;
        }
    }
}