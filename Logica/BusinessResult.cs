using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    /// <summary>
    /// Clase base para resultados de operaciones de negocio.
    /// </summary>
    public class BusinessResult
    {
        /// <summary>
        /// Indica si la operación fue exitosa (true si no hay errores).
        /// </summary>
        public bool Success => !Messages.Any();

        /// <summary>
        /// Lista de mensajes de error o información.
        /// </summary>
        public List<string> Messages { get; private set; } = new List<string>();

        /// <summary>
        /// Agrega un mensaje de error al resultado.
        /// </summary>
        public void AddError(string message)
        {
            if (!string.IsNullOrWhiteSpace(message))
                Messages.Add(message);
        }

        /// <summary>
        /// Indica si la operación contiene errores.
        /// </summary>
        public bool HasErrors => Messages.Count > 0;
    }

    /// <summary>
    /// Clase genérica para resultados que además devuelven datos (listas, DTOs, etc.).
    /// </summary>
    public class BusinessResult<T> : BusinessResult
    {
        /// <summary>
        /// Datos devueltos por la operación.
        /// </summary>
        public T Data { get; set; }
    }
}