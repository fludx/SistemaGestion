using Datos;
using Servicios;
using Sesion;
using System;

namespace Logica
{
    public class L_Restriccion
    {
        private readonly D_Restriccion dRestriccion = new D_Restriccion();
        private readonly ContEspeciales contEspeciales = new ContEspeciales();
        private readonly MinCaracteres minCaracteres = new MinCaracteres();
        private readonly ContNum contNum = new ContNum();
        private readonly MayusMinus mayusMinus = new MayusMinus();

        public string VerificarContraContraDatosPersonales(int idUsuario, string nuevaContrasena)
        {
            var estado = dRestriccion.ObtenerRestricciones();
            if (estado.DatosPersonales == 1)
            {
                string resultado = dRestriccion.VerificarContrasena(idUsuario, nuevaContrasena);
                return resultado;
            }

            return "OK";
        }
        public bool ObtenerCaracteresEspeciales(string contra)
        {
            var estado = dRestriccion.ObtenerRestricciones();

            if (estado.CaracterEsp == 1)
            {
                bool tieneEspecial = contEspeciales.ContieneCaracterEspecial(contra);

                if (!tieneEspecial)
                {
                    return false;
                }

                return true;
            }

            return true;
        }

        public bool ObtenerMinimoCaracteres(string contra)
        {
            var estado = dRestriccion.ObtenerRestricciones();

            if (estado.MinimoCar == 1)
            {
                int cantidad = estado.CaracteresUtilizados;

                string resultado = MinCaracteres.ValidarMinimoCaracteres(contra, cantidad);

                if (resultado != contra)
                {
                    Console.WriteLine(resultado);
                    return false;
                }

                return true;
            }

            return true;
        }

        public bool ObtenerNumeros(string contra)
        {
            var estado = dRestriccion.ObtenerRestricciones();

            if (estado.NumeroLetras == 1)
            {
                int cantidad = estado.CaracteresUtilizados;

                string resultado = contNum.ContieneNumeros(contra);

                if (resultado != contra)
                {
                    Console.WriteLine(resultado);
                    return false;
                }

                return true;
            }

            return true;
        }


        public bool ObtenerMayusculas(string contra)
        {
            var estado = dRestriccion.ObtenerRestricciones();

            if (estado.MayusMinus == 1)
            {
                bool tieneMayuscula = mayusMinus.ContieneMayusculas(contra);

                if (!tieneMayuscula)
                {
                    return false;
                }

                return true;
            }

            return true;
        }

        

        public EstadoRestricciones ConseguirRestricciones()
        {
            var estado = dRestriccion.ObtenerRestricciones();

            Console.WriteLine("\nRestricciones activas:");
            if (estado.MinimoCar == 1) Console.WriteLine("- Mínimo de caracteres");
            if (estado.MayusMinus == 1) Console.WriteLine("- Combinar mayúsculas y minúsculas");
            if (estado.NumeroLetras == 1) Console.WriteLine("- Contener números y letras");
            if (estado.CaracterEsp == 1) Console.WriteLine("- Contener un carácter especial");
            if (estado.ContrasenaAnterior == 1) Console.WriteLine("- No repetir contraseñas anteriores");
            if (estado.DatosPersonales == 1) Console.WriteLine("- No permitir datos personales");
            if (estado.DosFA == 1) Console.WriteLine("- Requiere autenticación 2FA por correo");

            Console.WriteLine("Finalizó la carga de restricciones.");

            return estado;
        }

        public void GuardarRestricciones(
            decimal minCaracteres,
            bool mayusMinus,
            bool numLetras,
            bool caracterEspecial,
            bool noRepetir,
            bool noDatosPersonales,
            bool dosFA)
        {
            dRestriccion.GuardarRestricciones(minCaracteres, mayusMinus, numLetras, caracterEspecial, noRepetir, noDatosPersonales, dosFA);
        }
    }
}
