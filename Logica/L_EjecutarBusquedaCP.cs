using System;
using Datos;

namespace Logica
{
    public class L_EjecutarBusquedaCP
    {
        public static string Localidad { get; private set; }
        public static string Partido { get; private set; }
        public static string Provincia { get; private set; }
        public static int idLocalidad { get; private set; }
        public static int idPartido { get; private set; }
        public static int idProvincia { get; private set; }

        public static bool BuscarCP(int CP)
        {
            D_BusquedaCP buscador = new D_BusquedaCP();
            var datos_cp = buscador.BusquedaDatosCp(CP);

            if (datos_cp != null)
            {
                Localidad = datos_cp.Localidad;
                Partido = datos_cp.Partido;
                Provincia = datos_cp.Provincia;

                idLocalidad = datos_cp.ÏdLocalidad;
                idPartido = datos_cp.IdPartido;
                idProvincia = datos_cp.IdProvincia;

                return true;
            }

            Localidad = "";
            Partido = "";
            Provincia = "";

            return false;
        }
    }
}