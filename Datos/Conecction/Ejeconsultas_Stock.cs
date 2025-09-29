using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Conecction
{
    public abstract class Ejeconsultas_Stock : Conexion_stock
    {
        public DataTable EjecConsultas(string NombreSP, SqlParameter[] sqlParam, bool Directa = false)
        {
            try
            {


                using (SqlConnection CNN = GetConexion())
                {
                    using (SqlCommand comando = new SqlCommand(NombreSP, CNN))
                    {
                        CNN.Open();
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.AddRange(sqlParam);
                        DataTable DT = new DataTable();


                        /* Dependiendo de la variable 'Directa', se va a leer la
                        consulta o modificar algo */

                        if (!Directa)
                        {

                            DT.Load(comando.ExecuteReader());
                        }
                        else
                        {
                            comando.ExecuteNonQuery();
                        }
                        return DT;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al ejecutar SP o Conexion a la BD. \n \n" + ex.Message);
            }
        }
    }
}
