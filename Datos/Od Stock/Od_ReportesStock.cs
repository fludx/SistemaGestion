using Datos.Conecction;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Datos.Od_Stock
{
    public class Od_ReportesStock : Ejeconsultas_Stock
    {
        public DataTable ReporteStockGeneral()
        {
            try
            {
                string nombreSP = "sp_ReporteStockGeneral";
                SqlParameter[] sqlParam = new SqlParameter[0];
                var dt = EjecConsultas(nombreSP, sqlParam);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al ejecutar reporte stock general: " + ex.Message);
            }
        }
    }
}