using System.Security.Cryptography;
using System.Text;

namespace Sesion
{
    public static class GeneradorContraseña
    {
        public static string Generar(int length = 10)
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
    }
}
