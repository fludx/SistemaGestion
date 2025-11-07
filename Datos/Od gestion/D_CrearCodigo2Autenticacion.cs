using System;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class D_CrearCodigo2Autenticacion
    {
        public int CrearCodigo2FA(int idUsuario, string codigo2FA, DateTime fechaGeneracion)
        {
            int idCodigo2FA = 0;
            Console.WriteLine(idUsuario);
            Console.WriteLine(codigo2FA);
            Console.WriteLine(fechaGeneracion);

            using (var conexion = Conecction.ConnectionBD.ObtenerConexion())
            {
                conexion.Open();
                using (var cmd = conexion.CreateCommand())
                {
                    cmd.CommandText = "sp_Generar2FACodigo";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Id_Usuario", idUsuario);
                    cmd.Parameters.AddWithValue("@CodigoGenerado", codigo2FA);

                    SqlParameter outputParam = new SqlParameter("@IdCodigo2FA", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(outputParam);

                    cmd.ExecuteNonQuery();

                    idCodigo2FA = Convert.ToInt32(outputParam.Value);
                }
            }

            return idCodigo2FA;
        }

    }
}
