using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.DTOs;
using Datos;

namespace Logica
{
    public class L_Lista
    {
        private D_Lista datos = new D_Lista();
        private D_ListaRol datosRol = new D_ListaRol();

        public List<KeyValuePair<int, string>> ObtenerPersonasParaCombo()
        {
            var personasDTO = datos.ListarPersonas(); 

            var listaCombo = new List<KeyValuePair<int, string>>();
            foreach (var persona in personasDTO)
            {
                listaCombo.Add(new KeyValuePair<int, string>(persona.Id_Persona, persona.NombreCompleto));
            }

            return listaCombo;
        }

        public List<KeyValuePair<int, string>> ObtenerRolesParaCombo()
        {
            var rolesDTO = datosRol.ListarRoles();

            var listarolCombo = new List<KeyValuePair<int, string>>();
            foreach (var rol in rolesDTO)
            {
                listarolCombo.Add(new KeyValuePair<int, string>(rol.Id_Rol, rol.Rol));
            }

            return listarolCombo;
        }
        public string ObtenerCorreoPorId(int idPersona)
        {
            var persona = datos.ListarPersonas().FirstOrDefault(p => p.Id_Persona == idPersona);
            if (persona != null)
            {
                return persona.email;
            }
            return string.Empty;
        }
    }
}
