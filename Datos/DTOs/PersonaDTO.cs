using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.DTOs
{
    public class PersonaDTO
    {
        public int Id_Persona { get; set; }
        public string NombreCompleto { get; set; }
        public string Num_Documento { get; set; }
        public string CUIL { get; set; }

        public string email { get; set; }
    }
}
