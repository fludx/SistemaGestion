using System;
using Datos;

namespace Logica
{
    public class L_Traer_Genero
    {
        public string Genero { get; set; }

        public int IdGenero { get; set; }

        public bool BuscarGenero()
        {
            var traerGeneroDatos = new D_Traer_Genero(); 

            int? id = traerGeneroDatos.ObtenerIdGenero(this.Genero);

            if (id.HasValue)
            {
                this.IdGenero = id.Value;
                return true;
            }

            return false;
        }
    }
}
