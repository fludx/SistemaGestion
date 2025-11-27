using Datos.Conecction;
using Datos.DTOs_Stock;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Datos.Od_Stock
{
    public class Od_OrdenesCompra : Ejeconsultas_Stock
    {
        public int CrearOrdenCompra(int idProveedor, DateTime fecha, string estado, string observaciones)
        {
            try
            {
                string nombreSP = "sp_CrearOrdenCompra";
                var parametros = new List<SqlParameter>
                {
                    new SqlParameter("@id_proveedor", SqlDbType.Int) { Value = idProveedor },
                    new SqlParameter("@fecha", SqlDbType.Date) { Value = fecha },
                    new SqlParameter("@estado", SqlDbType.NVarChar, 50) { Value = (object)estado ?? DBNull.Value },
                    new SqlParameter("@observaciones", SqlDbType.NVarChar, 500) { Value = (object)observaciones ?? DBNull.Value }
                };
                var dt = EjecConsultas(nombreSP, parametros.ToArray());
                if (dt != null && dt.Rows.Count > 0 && dt.Columns.Contains("id_orden_compra"))
                {
                    return Convert.ToInt32(dt.Rows[0]["id_orden_compra"]);
                }
                // fallback: intentar columna SCOPE_IDENTITY
                if (dt != null && dt.Rows.Count > 0 && dt.Columns.Contains("id"))
                {
                    return Convert.ToInt32(dt.Rows[0]["id"]);
                }
                return 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error creando orden de compra: " + ex.Message);
            }
        }

        public bool AgregarDetalleCompra(int idOrdenCompra, int idProducto, string lote, DateTime? vencimiento, int cantidad, decimal? precioUnitario)
        {
            try
            {
                string nombreSP = "sp_AgregarDetalleCompra";
                var parametros = new List<SqlParameter>
                {
                    new SqlParameter("@id_orden_compra", SqlDbType.Int) { Value = idOrdenCompra },
                    new SqlParameter("@id_producto", SqlDbType.Int) { Value = idProducto },
                    new SqlParameter("@lote", SqlDbType.NVarChar, 50) { Value = (object)lote ?? DBNull.Value },
                    new SqlParameter("@vencimiento", SqlDbType.Date) { Value = (object)vencimiento ?? DBNull.Value },
                    new SqlParameter("@cantidad", SqlDbType.Int) { Value = cantidad },
                    new SqlParameter("@precio_unitario", SqlDbType.Decimal) { Precision = 18, Scale = 2, Value = (object)precioUnitario ?? DBNull.Value }
                };
                EjecConsultas(nombreSP, parametros.ToArray(), true);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error agregando detalle de compra: " + ex.Message);
            }
        }

        public DataTable ListarOrdenesPendientes()
        {
            try
            {
                // Consulta directa a la tabla Ordenes_Compra para mostrar pendientes
                string sql = "SELECT id_orden_compra, id_proveedor, fecha, estado, observaciones FROM Ordenes_Compra WHERE estado = 'Pendiente' ORDER BY fecha DESC";
                // Ejecutar como consulta directa: usamos EjecConsultas con un comando de texto no soportado por el helper (EjecConsultas espera SP).
                // En vez de cambiar Ejeconsultas_Stock, ejecutamos un SP temporal: reutilizamos EjecConsultas con nombre SP y sin parámetros si existe sp_ListarOrdenes, else uso consulta directa con SqlConnection.
                using (var cnn = Conexion_stock.GetConexion())
                using (var cmd = new SqlCommand(sql, cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    var dt = new DataTable();
                    cnn.Open();
                    dt.Load(cmd.ExecuteReader());
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error listando ordenes pendientes: " + ex.Message);
            }
        }

        public DataTable ObtenerDetalleOrden(int idOrdenCompra)
        {
            try
            {
                string sql = @"SELECT id_detalle, id_producto, lote, vencimiento, cantidad, precio_unitario
                               FROM Ordenes_Compra_Detalle
                               WHERE id_orden_compra = @id_orden_compra";
                using (var cnn = Conexion_stock.GetConexion())
                using (var cmd = new SqlCommand(sql, cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@id_orden_compra", idOrdenCompra);
                    var dt = new DataTable();
                    cnn.Open();
                    dt.Load(cmd.ExecuteReader());
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error obteniendo detalle de OC: " + ex.Message);
            }
        }

        public bool RegistrarRecepcionCompra(int idOrdenCompra, string usuario = null)
        {
            try
            {
                string nombreSP = "sp_RegistrarRecepcionCompra";
                var parametros = new List<SqlParameter>
                {
                    new SqlParameter("@id_orden_compra", SqlDbType.Int) { Value = idOrdenCompra },
                    new SqlParameter("@usuario", SqlDbType.NVarChar, 100) { Value = (object)usuario ?? DBNull.Value }
                };
                EjecConsultas(nombreSP, parametros.ToArray(), true);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error registrando recepcion de compra: " + ex.Message);
            }
        }
    }
}