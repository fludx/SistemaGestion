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
    public class Od_ListarClientes : Ejeconsultas_Stock
    {
        public List<ClienteListadoDTO> ListarClientes()
        {
            try
            {
                string nombreSP = "sp_ListarClientes";

                // Este SP no requiere parámetros
                SqlParameter[] sqlParam = new SqlParameter[0];

                // Ejecutar el SP
                DataTable dt = EjecConsultas(nombreSP, sqlParam);

                // Procesar el resultado
                List<ClienteListadoDTO> listaClientes = new List<ClienteListadoDTO>();

                foreach (DataRow row in dt.Rows)
                {
                    listaClientes.Add(new ClienteListadoDTO
                    {
                        IdCliente = Convert.ToInt32(row["id_cliente"]),
                        Codigo = row["codigo"].ToString(),
                        RazonSocial = row["razon_social"].ToString(),
                        Email = row["email"].ToString(),
                        FormasPago = row["formas_pago"].ToString(),
                        Descuentos = row["descuentos"].ToString(),
                        LimiteCredito = Convert.ToDecimal(row["limite_credito"])
                    });
                }

                return listaClientes;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar los clientes: " + ex.Message);
            }
        }
    }
}
