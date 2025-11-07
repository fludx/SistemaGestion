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
    public class Od_AgregarDetalleVenta : Ejeconsultas_Stock
    {
        public bool AgregarDetalleVenta(DetalleVentaDTO detalle)
        {
            try
            {
                string nombreSP = "sp_AgregarDetalleVenta";

                // Lista de parámetros para el SP
                List<SqlParameter> parametros = new List<SqlParameter>
                {
                    new SqlParameter("@id_venta", SqlDbType.Int) { Value = detalle.IdVenta },
                    new SqlParameter("@id_producto", SqlDbType.Int) { Value = detalle.IdProducto },
                    new SqlParameter("@cantidad", SqlDbType.Int) { Value = detalle.Cantidad },
                    new SqlParameter("@precio_unitario", SqlDbType.Decimal)
                    {
                        Precision = 18,
                        Scale = 2,
                        Value = detalle.PrecioUnitario
                    },
                    new SqlParameter("@descuento", SqlDbType.Decimal)
                    {
                        Precision = 18,
                        Scale = 2,
                        Value = (object)detalle.Descuento ?? DBNull.Value
                    },
                    new SqlParameter("@observaciones", SqlDbType.NVarChar, 255)
                    {
                        Value = (object)detalle.Observaciones ?? DBNull.Value
                    }
                };

                SqlParameter[] sqlParam = parametros.ToArray();

                // Ejecutar el procedimiento almacenado
                DataTable dt = EjecConsultas(nombreSP, sqlParam);

                // Si devuelve filas, consideramos que se insertó correctamente
                return dt.Rows.Count > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar el detalle de venta: " + ex.Message);
            }
        }
    }
}
