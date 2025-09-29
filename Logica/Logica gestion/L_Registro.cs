using System;
using Datos;

namespace Logica
{
    public class L_Registro
    {
        public bool RegistrarPersona(
            string nombre,
            string apellido,
            string tipoDocumento,
            string numDocumento,
            string cuil,
            string calle,
            string altura,
            string piso,
            string departamento,
            string codigoPostal,
            int idProvincia,
            int idPartido,
            int idLocalidad,
            int idGenero,
            bool sexo,
            string email,
            DateTime fechaAlta
        )
        {
            return D_Registro.RegistrarPersona(
                nombre,
                apellido,
                tipoDocumento,
                numDocumento,
                cuil,
                calle,
                altura,
                piso,
                departamento,
                codigoPostal,
                idProvincia,
                idPartido,
                idLocalidad,
                idGenero,
                sexo,
                email,
                fechaAlta
            );
        }
    }
}
