using Datos.Conecction;
using Datos.DTOs_Stock;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Datos.Od_Stock
{
    public class Od_ProductosProximosVencer : Ejeconsultas_Stock
    {
        public List<ProductoVencimientoDTO> Consultar(int dias)
        {
            try
            {
                string nombreSP = "sp_ProductosProximosVencer";
                SqlParameter[] sqlParam = new SqlParameter[]
                {
                    new SqlParameter("@dias", SqlDbType.Int) { Value = dias }
                };

                DataTable dt = EjecConsultas(nombreSP, sqlParam);

                var list = new List<ProductoVencimientoDTO>();

                foreach (DataRow r in dt.Rows)
                {
                    list.Add(new ProductoVencimientoDTO
                    {
                        IdProducto = r.Table.Columns.Contains("id_producto") && r["id_producto"] != DBNull.Value ? Convert.ToInt32(r["id_producto"]) : 0,
                        Codigo = r.Table.Columns.Contains("codigo") && r["codigo"] != DBNull.Value ? r["codigo"].ToString() : "",
                        Nombre = r.Table.Columns.Contains("nombre") && r["nombre"] != DBNull.Value ? r["nombre"].ToString() : "",
                        Lote = r.Table.Columns.Contains("lote") && r["lote"] != DBNull.Value ? r["lote"].ToString() : "",
                        Vencimiento = r.Table.Columns.Contains("vencimiento") && r["vencimiento"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(r["vencimiento"]) : null,
                        Cantidad = r.Table.Columns.Contains("cantidad") && r["cantidad"] != DBNull.Value ? Convert.ToInt32(r["cantidad"]) : 0
                    });
                }

                return list;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al ejecutar sp_ProductosProximosVencer: " + ex.Message);
            }
        }
    }
}