using Datos.Conecction;
using Datos.DTOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos

{
    public class D_HistorialContras
    {
        public List<HistorialContrasDTO> ContrasenasAnteriores(string usuario)
        {
            List<HistorialContrasDTO> lista = new List<HistorialContrasDTO>();

            try
            {
                using (SqlConnection conexion = ConnectionBD.ObtenerConexion())
                {
                    conexion.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_BuscarContrasenas", conexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@usuario", usuario);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {

                            while (reader.Read())
                            {
                                HistorialContrasDTO historial = new HistorialContrasDTO
                                {
                                    id_Contrasena = Convert.ToInt32(reader["Id_Historial"]),
                                    contrasena = reader["Contrasena"].ToString()
                                };

                                lista.Add(historial);
                            }
                        }
                    }


                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar las contraseñas del usuario: ", ex);
            }

            if (lista.Count > 0) return lista;
            else return null;
        }
    }
}
