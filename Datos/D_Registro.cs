using Datos.Conecction;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class D_Registro
    {
        public static bool RegistrarPersona(
            string nombre,
            string apellido,
            string tipoDocumento,
            string numDocumento,
            string cuil,
            string calle,
            string altura,
            string piso,
            string departamento,
            string codigoPostal,
            int idProvincia,
            int idPartido,
            int idLocalidad,
            int idGenero,
            bool sexo,
            string email,
            DateTime fechaAlta
        )
        {
            try
            {
                using (SqlConnection conexion = ConnectionBD.ObtenerConexion())
                {
                    conexion.Open();

                    using (SqlCommand cmd = new SqlCommand("sp_Registro", conexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;


                        cmd.Parameters.AddWithValue("@Nombre", nombre);
                        cmd.Parameters.AddWithValue("@Apellido", apellido);
                        cmd.Parameters.AddWithValue("@Tipo_Documento", tipoDocumento);
                        cmd.Parameters.AddWithValue("@Num_Documento", numDocumento);
                        cmd.Parameters.AddWithValue("@CUIL", cuil);
                        cmd.Parameters.AddWithValue("@Calle", calle);
                        cmd.Parameters.AddWithValue("@Altura", altura);

                        if (string.IsNullOrEmpty(piso))
                            cmd.Parameters.AddWithValue("@Piso", DBNull.Value);
                        else
                            cmd.Parameters.AddWithValue("@Piso", piso);

                        if (string.IsNullOrEmpty(departamento))
                            cmd.Parameters.AddWithValue("@Departamento", DBNull.Value);
                        else
                            cmd.Parameters.AddWithValue("@Departamento", departamento);

                        cmd.Parameters.AddWithValue("@Codigo_Postal", codigoPostal);
                        cmd.Parameters.AddWithValue("@Id_Provincia", idProvincia);
                        cmd.Parameters.AddWithValue("@Id_Partido", idPartido);
                        cmd.Parameters.AddWithValue("@Id_Localidad", idLocalidad);
                        cmd.Parameters.AddWithValue("@Id_Genero", idGenero);
                        cmd.Parameters.AddWithValue("@Sexo", sexo);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@FechaAlta", fechaAlta);

              
                        int filasAfectadas = cmd.ExecuteNonQuery();


                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en registrar persona", ex);
                return false;
            }
        }
    }
}
