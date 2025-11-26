using Datos.Conecction;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Datos.Od_Stock
{
    public class Od_Categorias : Ejeconsultas_Stock
    {
        public bool ExisteCategoria(int idCategoria)
        {
            try
            {
                string nombreSP = "sp_ExisteCategoria";
                SqlParameter[] sqlParam = new SqlParameter[]
                {
                    new SqlParameter("@id_categoria", SqlDbType.Int) { Value = idCategoria }
                };

                DataTable dt = EjecConsultas(nombreSP, sqlParam);
                if (dt.Rows.Count == 0) return false;
                return Convert.ToInt32(dt.Rows[0]["Existe"]) == 1;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Listar categorías: uso SELECT directo para evitar dependencia de SP ausente.
        public DataTable ListarCategorias()
        {
            try
            {
                using (var conn = GetConexion())
                using (var cmd = new SqlCommand("SELECT id_categoria, nombre FROM Categorias ORDER BY nombre", conn))
                using (var da = new SqlDataAdapter(cmd))
                {
                    var dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
            catch (Exception)
            {
                return new DataTable();
            }
        }
    }
}