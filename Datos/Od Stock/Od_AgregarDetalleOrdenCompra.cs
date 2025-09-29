using Datos.Conecction;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Od_Stock
{
    public class Od_AgregarDetalleOrdenCompra : Ejeconsultas_Stock
    {
    }public List<> CargarRemito(string codVenta)
        {
            // Crear una lista nueva cada vez que se cargue el combo
            List<M_DatosRemito> lista = new List<M_DatosRemito>();
            try
            {
                string NombreSP = "SP_FiltrarPorCodVenta";

                List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@codventa", SqlDbType.VarChar, 30) { Value = codVenta }
            };

                SqlParameter[] sqlParam = parametros.ToArray();

                // Llamar a EjecConsultas y procesar el resultado en CargaLista
                return CargaLista(EjecConsultas(NombreSP, sqlParam), lista);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private List<M_DatosRemito> CargaLista(DataTable DT, List<M_DatosRemito> lista)
        {
            foreach (DataRow row in DT.Rows)
            {
                lista.Add(new M_DatosRemito
                {
                    IDENTIFICADOR = row["codigo"].ToString(),
                    FECHA = Convert.ToDateTime(row["fecha"]),
                    MODELO = row["modelo"].ToString(),
                    NRO_SERIE = row["nroserie"].ToString(),
                    ENCARGADO = row["encargado"].ToString(),
                    COD_VENTA = row["cod_venta"].ToString(),
                    MAL_TRANSPORTADO = Convert.ToBoolean(row["estado"])
                });
            }
            return lista;
        }
    }
}
