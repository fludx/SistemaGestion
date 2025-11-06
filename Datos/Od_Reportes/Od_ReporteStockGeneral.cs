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
    public class Od_ReporteStockGeneral : Ejeconsultas_Stock
    {
        public List<ReporteStockGeneralDTO> ObtenerReporteStockGeneral()
        {
            try
            {
                string nombreSP = "sp_ReporteStockGeneral";

                // No requiere parámetros según el SP
                SqlParameter[] parametros = new SqlParameter[0];

                DataTable dt = EjecConsultas(nombreSP, parametros);

                List<ReporteStockGeneralDTO> lista = new List<ReporteStockGeneralDTO>();

                foreach (DataRow row in dt.Rows)
                {
                    ReporteStockGeneralDTO reporte = new ReporteStockGeneralDTO
                    {
                        IdProducto = Convert.ToInt32(row["id_producto"]),
                        Codigo = row["codigo"].ToString(),
                        Nombre = row["nombre"].ToString(),
                        StockTotal = row["stock_total"] != DBNull.Value ? Convert.ToInt32(row["stock_total"]) : 0,
                        StockMinimo = row["stock_minimo"] != DBNull.Value ? Convert.ToInt32(row["stock_minimo"]) : 0,
                        PuntoReposicion = row["punto_reposicion"] != DBNull.Value ? Convert.ToInt32(row["punto_reposicion"]) : 0
                    };

                    lista.Add(reporte);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el reporte de stock general: " + ex.Message);
            }
        }
    }
}
