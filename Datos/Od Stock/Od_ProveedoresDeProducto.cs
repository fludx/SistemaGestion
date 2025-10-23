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
    public class Od_ProveedoresDeProducto : Ejeconsultas_Stock
    {
        public List<ProveedorDeProductoDTO> ConsultarProveedoresDeProducto(int idProducto)
        {
            try
            {
                string nombreSP = "sp_ConsultarProveedoresDeProducto";

                // Parámetros del procedimiento almacenado
                List<SqlParameter> parametros = new List<SqlParameter>
                {
                    new SqlParameter("@id_producto", SqlDbType.Int) { Value = idProducto }
                };

                SqlParameter[] sqlParam = parametros.ToArray();

                // Ejecutar el SP y obtener el DataTable
                DataTable dt = EjecConsultas(nombreSP, sqlParam);

                // Procesar el resultado y devolver una lista de DTOs
                List<ProveedorDeProductoDTO> proveedores = new List<ProveedorDeProductoDTO>();
                foreach (DataRow row in dt.Rows)
                {
                    proveedores.Add(new ProveedorDeProductoDTO
                    {
                        IdProveedor = Convert.ToInt32(row["id_proveedor"]),
                        CodigoProveedor = row["codigo"].ToString(),
                        RazonSocial = row["razon_social"].ToString(),
                        Email = row["email"].ToString(),
                        FormasPago = row["formas_pago"].ToString(),
                        TiemposEntrega = row["tiempos_entrega"].ToString(),
                        Descuentos = row["descuentos"].ToString()
                    });
                }

                return proveedores;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar los proveedores del producto: " + ex.Message);
            }
        }
    }
}