using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class L_CrearCodigo2FA
    {
        public void CrearCodigo2FA(int idUsuario, string codigo2FA, DateTime fechaGeneracion)
        {
            D_CrearCodigo2Autenticacion datos = new D_CrearCodigo2Autenticacion();
            datos.CrearCodigo2FA(idUsuario, codigo2FA, fechaGeneracion);
        }

    }
}
