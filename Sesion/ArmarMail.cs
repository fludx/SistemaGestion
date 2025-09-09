namespace Sesion
{
    public class ArmarMail
    {
        public static string DireccionCorreo { get; set; }
        public static string Asunto { get; set; }
        public static string ContrasenaSistema { get; set; }


        public static void Preparar()
        {
            string body = $@"
                <style>
                    h1{{color:dodgerblue;}}
                    h2{{color:darkorange;}}
                </style>
                <h1>Contraseña dada por el sistema:</h1><br/>
                <h2>{ContrasenaSistema}</h2>";


            EnviarMail.SendCustomMail(DireccionCorreo, Asunto, body);
        }
    }
}
