using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Datos.Conecction;
using Datos;
using Sesion;


namespace Logica
{
    public class L_Login
    {
        public static bool LoginUsuario(string usuario, string contrasena, out int idUsuario, out bool esAdmin, out string nombreRol)
        {
            idUsuario = D_Login.LoginBD(usuario, contrasena, out esAdmin, out nombreRol);
            SesionUsuario.IdUsuario = idUsuario;
            return idUsuario > 0;
        }
    }
}