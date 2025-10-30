using Datos.Conecction;
using Datos.DTOs_Stock;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Od_Stock
{
    public class Od_VerificarPuntoReposicion : Ejeconsultas_Stock
    {
        public List<VerificarPuntoReposicionDTO> ObtenerProductosBajoReposicion()
        {
            try
            {
                string nombreSP = "sp_VerificarPuntoReposicion";

                // No tiene parámetros
                SqlParameter[] parametros = new SqlParameter[0];

                DataTable dt = EjecConsultas(nombreSP, parametros);

                List<VerificarPuntoReposicionDTO> lista = new List<VerificarPuntoReposicionDTO>();

                foreach (DataRow row in dt.Rows)
                {
                    VerificarPuntoReposicionDTO item = new VerificarPuntoReposicionDTO
                    {
                        IdProducto = Convert.ToInt32(row["id_producto"]),
                        Codigo = row["codigo"].ToString(),
                        Nombre = row["nombre"].ToString(),
                        PuntoReposicion = row["punto_reposicion"] != DBNull.Value ? Convert.ToInt32(row["punto_reposicion"]) : 0,
                        StockTotal = row["stock_total"] != DBNull.Value ? Convert.ToInt32(row["stock_total"]) : 0
                    };

                    lista.Add(item);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al verificar productos bajo punto de reposición: " + ex.Message);
            }
        }
    }
}
