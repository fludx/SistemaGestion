using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.Conecction;
using System.Data;
using System.Data.SqlClient;
using Datos.DTOs;

namespace Datos
{
    public class D_Lista
    {
        public List<PersonaDTO> ListarPersonas()
        {
            List<PersonaDTO> lista = new List<PersonaDTO>();

            try
            {
                using (SqlConnection conexion = ConnectionBD.ObtenerConexion())
                {
                    conexion.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_PersonasSinUsuario", conexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                PersonaDTO persona = new PersonaDTO
                                {
                                    Id_Persona = Convert.ToInt32(reader["Id_Persona"]),
                                    NombreCompleto = reader["NombreCompleto"].ToString(),
                                    Num_Documento = reader["Num_Documento"].ToString(),
                                    CUIL = reader["CUIL"].ToString(),
                                    email = reader["Email"].ToString(),
                                };

                                lista.Add(persona);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar personas sin usuario", ex);
            }

            return lista;
        }
    }


}

