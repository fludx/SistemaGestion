using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    
    /// Clase base para resultados de operaciones de negocio.
  
    public class BusinessResult
    {
        public bool Success => !Messages.Any();

        public List<string> Messages { get; private set; } = new List<string>();

        public void AddError(string message)
        {
            if (!string.IsNullOrWhiteSpace(message))
                Messages.Add(message);
        }

        public bool HasErrors => Messages.Count > 0;
    }

    public class BusinessResult<T> : BusinessResult
    {
        public T Data { get; set; }
    }
}