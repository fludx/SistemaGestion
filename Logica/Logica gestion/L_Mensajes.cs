using MensajeriaApp.Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MensajeriaApp.Logica
{
    public class L_Mensajes
    {
        private D_Mensajes dal = new D_Mensajes();

        public void Enviar(int emisorId, int receptorId, string mensaje)
        {
            if (string.IsNullOrWhiteSpace(mensaje))
                throw new Exception("El mensaje no puede estar vacío.");

            dal.EnviarMensaje(emisorId, receptorId, mensaje);
        }

        public DataTable BandejaEntrada(int usuarioId)
        {
            return dal.ObtenerMensajes(usuarioId);
        }

        public DataTable ObtenerConversacion(int usuario1Id, int usuario2Id)
        {
            return dal.ObtenerConversacion(usuario1Id, usuario2Id);
        }

    }
}