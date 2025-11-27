using Datos.Conecction;
using Datos.DTOs_Stock;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Datos.Od_Stock
{
    public class Od_VerificarPuntoReposicion : Ejeconsultas_Stock
    {
        public List<VerificarPuntoReposicionDTO> ObtenerProductosBajoReposicion()
        {
            try
            {
                string nombreSP = "sp_VerificarPuntoReposicion";
                SqlParameter[] sqlParam = new SqlParameter[0];

                DataTable dt = EjecConsultas(nombreSP, sqlParam);

                var list = new List<VerificarPuntoReposicionDTO>();

                foreach (DataRow r in dt.Rows)
                {
                    list.Add(new VerificarPuntoReposicionDTO
                    {
                        IdProducto = r.Table.Columns.Contains("id_producto") && r["id_producto"] != DBNull.Value ? Convert.ToInt32(r["id_producto"]) : 0,
                        Codigo = r.Table.Columns.Contains("codigo") && r["codigo"] != DBNull.Value ? r["codigo"].ToString() : "",
                        Nombre = r.Table.Columns.Contains("nombre") && r["nombre"] != DBNull.Value ? r["nombre"].ToString() : "",
                        PuntoReposicion = r.Table.Columns.Contains("punto_reposicion") && r["punto_reposicion"] != DBNull.Value ? Convert.ToInt32(r["punto_reposicion"]) : 0,
                        StockTotal = r.Table.Columns.Contains("stock_total") && r["stock_total"] != DBNull.Value ? Convert.ToInt32(r["stock_total"]) : 0
                    });
                }

                return list;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al ejecutar sp_VerificarPuntoReposicion: " + ex.Message);
            }
        }

        // Wrapper con el nombre esperado por la capa de negocio
        public List<VerificarPuntoReposicionDTO> Verificar()
        {
            return ObtenerProductosBajoReposicion();
        }
    }
}