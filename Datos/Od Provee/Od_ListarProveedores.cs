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
    public class Od_ListarProveedores : Ejeconsultas_Stock
    {
        public List<ProveedorListadoDTO> ListarProveedores()
        {
            try
            {
                string nombreSP = "sp_ListarProveedores";

                // Este SP no requiere parámetros
                SqlParameter[] sqlParam = new SqlParameter[0];

                // Ejecutar el procedimiento
                DataTable dt = EjecConsultas(nombreSP, sqlParam);

                // Procesar los resultados
                List<ProveedorListadoDTO> lista = new List<ProveedorListadoDTO>();

                foreach (DataRow row in dt.Rows)
                {
                    lista.Add(new ProveedorListadoDTO
                    {
                        IdProveedor = Convert.ToInt32(row["id_proveedor"]),
                        Codigo = row["codigo"].ToString(),
                        RazonSocial = row["razon_social"].ToString(),
                        Email = row["email"].ToString(),
                        FormasPago = row["formas_pago"].ToString(),
                        TiemposEntrega = row["tiempos_entrega"].ToString(),
                        Descuentos = row["descuentos"].ToString()
                    });
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar los proveedores: " + ex.Message);
            }
        }
    }
}
