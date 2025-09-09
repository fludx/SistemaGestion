using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Sesion
{
    internal class PrimerContra
    {
        private static readonly string[] preguntasdeseguridad = new string[]
        {
            "¿Nombre de tu primera mascota?",
            "¿Ciudad donde naciste?",
            "¿Nombre de tu escuela primaria?",
            "¿Nombre de tu mejor amigo de la infancia?"
        };

        public static string Generarcontrarandom(int length = 10)
        {
            const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%&*";
            StringBuilder password = new StringBuilder();
            using (var rng = RandomNumberGenerator.Create())
            {
                byte[] buffer = new byte[1];
                for (int i = 0; i < length; i++)
                {
                    rng.GetBytes(buffer);
                    int index = buffer[0] % chars.Length;
                    password.Append(chars[index]);
                }
            }
            return password.ToString();
        }

        public static List<string> Mostrarpreguntas()
        {
            return new List<string>(preguntasdeseguridad);
        }

        public class NuevoUsuario
        {
            public string Username { get; set; }
            public string HashedPassword { get; set; }
            public bool DebeCambiarContraseña { get; set; } = true;
            public Dictionary<string, string> PreguntasSeguridad { get; set; }
        }

        public static NuevoUsuario CrearNuevoUsuario(string username, Dictionary<string, string> respuestas)
        {
            string passwordGenerada = Generarcontrarandom();
            string hash = HashconUsu.Hashconusu(username, passwordGenerada);

            return new NuevoUsuario
            {
                Username = username,
                HashedPassword = hash,
                DebeCambiarContraseña = true,
                PreguntasSeguridad = respuestas
            };
        }
    }
}
