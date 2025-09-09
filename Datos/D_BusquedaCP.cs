using System;
using System.Data;
using System.Data.SqlClient;
using Datos.Conecction;
using Datos.DTOs;

namespace Datos
{
    public class D_BusquedaCP
    {
        public CodigoPostalDTO BusquedaDatosCp(int cp)
        {
            try
            {
                using (SqlConnection conexion = ConnectionBD.ObtenerConexion())
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_CodigoPostal", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@CodigoPostal", cp);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new CodigoPostalDTO
                            {
                                Localidad = reader["Localidades"].ToString(),
                                Partido = reader["Partidos"].ToString(),
                                Provincia = reader["Provincias"].ToString(),
                                ÏdLocalidad = reader.GetInt32(reader.GetOrdinal("Id_Localidad")),
                                IdPartido = reader.GetInt32(reader.GetOrdinal("Id_Partido")),
                                IdProvincia = reader.GetInt32(reader.GetOrdinal("Id_Provincia"))
                            };
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al buscar los datos del código postal: " + ex.Message);
                return null;
            }
        }
    }
}