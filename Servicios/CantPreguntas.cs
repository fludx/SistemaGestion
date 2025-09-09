using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class CantPreguntas
    {
        public List<string> TraerPreguntas(List<string> preguntas, int cantidad)
        {
            if (cantidad <= 0 || cantidad > preguntas.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(cantidad), "La cantidad debe ser mayor que 0 y menor o igual al número de preguntas disponibles.");
            }else
            {
                Random random = new Random();
                List<string> preguntasSeleccionadas = new List<string>();
                HashSet<int> indicesSeleccionados = new HashSet<int>();
                while (preguntasSeleccionadas.Count < cantidad)
                {
                    int index = random.Next(preguntas.Count);
                    if (!indicesSeleccionados.Contains(index))
                    {
                        indicesSeleccionados.Add(index);
                        preguntasSeleccionadas.Add(preguntas[index]);
                    }
                }
                return preguntasSeleccionadas;
            }
            
        }
    }
}
