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
    public class Od_ConsultarDetalleOrdenCompra : Ejeconsultas_Stock
    {
        public List<DetalleOrdenCompraDTO_1> ConsultarDetalleOrdenCompra(int idOrdenCompra)
        {
            try
            {
                string nombreSP = "sp_ConsultarDetalleOrdenCompra";

                // Parámetros del procedimiento almacenado
                List<SqlParameter> parametros = new List<SqlParameter>
                {
                    new SqlParameter("@id_orden_compra", SqlDbType.Int) { Value = idOrdenCompra }
                };

                SqlParameter[] sqlParam = parametros.ToArray();

                // Ejecutar el SP y obtener el DataTable
                DataTable dt = EjecConsultas(nombreSP, sqlParam);

                // Procesar el resultado y devolver una lista de DTOs
                List<DetalleOrdenCompraDTO_1> detalles = new List<DetalleOrdenCompraDTO_1>();
                foreach (DataRow row in dt.Rows)
                {
                    detalles.Add(new DetalleOrdenCompraDTO_1
                    {
                        IdOrdenCompra = Convert.ToInt32(row["id_orden_compra"]),
                        IdProducto = Convert.ToInt32(row["id_producto"]),
                        NombreProducto = row["nombre_producto"].ToString(),
                        Lote = row["lote"].ToString(),
                        Vencimiento = row["vencimiento"] as DateTime?,
                        Cantidad = Convert.ToInt32(row["cantidad"]),
                        PrecioUnitario = row["precio_unitario"] as decimal?
                    });
                }

                return detalles;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar detalle de la orden de compra: " + ex.Message);
            }
        }
    }
}
