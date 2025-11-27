using System.Data;
using Datos.Od_Stock;

namespace Negocio
{
    public class N_Reportes
    {
        private readonly Od_ReportesStock odReport = new Od_ReportesStock();

        public BusinessResult<DataTable> ReporteStockGeneral()
        {
            var res = new BusinessResult<DataTable>();
            try
            {
                res.Data = odReport.ReporteStockGeneral();
                return res;
            }
            catch (System.Exception ex)
            {
                res.AddError("Error obteniendo reporte: " + ex.Message);
                return res;
            }
        }
    }
}