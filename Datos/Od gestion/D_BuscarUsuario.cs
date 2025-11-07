using System;
using System.Data;
using System.Data.SqlClient;
using Datos.Conecction;

public class D_BuscarUsuario
{
    public int? ObtenerIdPorUsuario(string usuario)
    {
        int? idUsuario = null;

        using (var conexion = ConnectionBD.ObtenerConexion())
        {
            conexion.Open();
            using (var cmd = new SqlCommand("sp_BuscarUsuario", conexion))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@usuario", usuario);

                var result = cmd.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                    idUsuario = Convert.ToInt32(result);
            }
        }

        return idUsuario;
    }

    public string ObtenerCorreoPorUsuario(int idUsuario)
    {
        using (var conexion = ConnectionBD.ObtenerConexion())
        {
            conexion.Open();
            using (var cmd = new SqlCommand("sp_ObtenerCorreoPorIdUsuario", conexion))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_Usuario", idUsuario);

                var result = cmd.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                    return result.ToString();
            }
        }
        return null;
    }


}
