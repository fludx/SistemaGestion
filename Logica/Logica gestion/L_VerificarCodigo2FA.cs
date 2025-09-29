using Datos;

namespace Logica
{
    public class L_VerificarCodigo2FA
    {
        private D_Verificacion2FA datos = new D_Verificacion2FA();

        public (string Codigo, int IdCodigo2FA) CrearCodigo2FA(int idUsuario, string codigoGenerado)
        {
            return datos.CrearCodigo2FA(idUsuario, codigoGenerado);
        }

        public bool VerificarCodigo(int idUsuario, string codigoIngresado)
        {
            return datos.ValidarCodigoIngresado(idUsuario, codigoIngresado);
        }
    }
}
