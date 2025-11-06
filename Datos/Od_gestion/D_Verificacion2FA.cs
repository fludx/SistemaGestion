using System;
using System.Data;
using System.Data.SqlClient;
using Datos.Conecction;

namespace Datos
{
        public class D_Verificacion2FA
        {
        public (string CodigoGenerado, int IdCodigo2FA) CrearCodigo2FA(int idUsuario, string codigoGenerado)
        {
            try
            {
                using (SqlConnection conn = ConnectionBD.ObtenerConexion())
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand("sp_Generar2FACodigo", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Id_Usuario", idUsuario);
                        cmd.Parameters.AddWithValue("@CodigoGenerado", codigoGenerado);

                        SqlParameter outputId = new SqlParameter("@IdCodigo2FA", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        cmd.Parameters.Add(outputId);

                        cmd.ExecuteNonQuery();

                        int idCodigo2FA = Convert.ToInt32(outputId.Value);

                        return (codigoGenerado, idCodigo2FA);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al crear código 2FA: " + ex.Message);
                return (null, 0);
            }
        }

            public bool ValidarCodigoIngresado(int idUsuario, string codigoIngresado)
        {
            try
            {
                using (SqlConnection conn = ConnectionBD.ObtenerConexion())
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand("sp_Validar2FACodigo", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Id_Usuario", idUsuario);
                        cmd.Parameters.AddWithValue("@CodigoIngresado", codigoIngresado);

                        SqlParameter esValido = new SqlParameter("@EsValido", SqlDbType.Bit)
                        {
                            Direction = ParameterDirection.Output
                        };
                        cmd.Parameters.Add(esValido);

                        cmd.ExecuteNonQuery();
                        return Convert.ToBoolean(esValido.Value);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al validar el código 2FA: " + ex.Message);
                return false;
            }
        }
    }
}
