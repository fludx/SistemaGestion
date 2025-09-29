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
    public class D_ListaRol
    {
        public List<RolDTO> ListarRoles()
        {
            List<RolDTO> lista = new List<RolDTO>();

            try
            {
                using (SqlConnection conexion = ConnectionBD.ObtenerConexion())
                {
                    conexion.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_ListarRoles", conexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                RolDTO rol = new RolDTO
                                {
                                    Id_Rol = Convert.ToInt32(reader["Id_Rol"]),
                                    Rol = reader["Rol"].ToString(),
                                };

                                lista.Add(rol);
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
