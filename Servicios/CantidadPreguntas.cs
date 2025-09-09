using System;

namespace Servicios
{
    public class CantidadPreguntas
    {

        // Valida que la cantidad de preguntas sea mayor igual a la cantidad de preguntas que asigno el admin en la tabla Restricciones
        public static void ValidarCantidadPreguntas(ObjetoPreguntas obj, int respuestas)
        {
            if (obj.preguntas != respuestas)
            {
                throw new ArgumentException("Completa todas las preguntas");
            }

        }
    }
}