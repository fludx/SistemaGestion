using Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class L_ListarPersonas
    {
        private D_ListarPersonas dal = new D_ListarPersonas();

        public DataTable ListarPersonas()
        {
            return dal.ListarPersonas();
        }
    }
}