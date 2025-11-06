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
    public class D_CrearRespuesta
    {
        public static bool CrearRespuesta(int idusuario, int idpregunta, string respuesta, out string mensaje)
        {
            mensaje = null;

            try
            {
                using (SqlConnection conexion = ConnectionBD.ObtenerConexion())
                {
                    conexion.Open();

                    using (SqlCommand cmd = new SqlCommand("sp_ResponderPregunta", conexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@idusuario", idusuario);
                        cmd.Parameters.AddWithValue("@respuesta", respuesta);
                        cmd.Parameters.AddWithValue("@idpregunta", idpregunta);

                        cmd.ExecuteNonQuery();

                        mensaje = "Pregunta creada correctamente.";
                        return true;
                    }
                }
            }
            catch (SqlException ex)
            {

                mensaje = "Error al crear la pregunta: " + ex.Message;
                return false;
            }
            catch (Exception ex)
            {
                mensaje = "Error inesperado: " + ex.Message;
                return false;
            }
        }
    }
}
