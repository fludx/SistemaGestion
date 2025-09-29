using Datos;
using Datos.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Logica
{
    // DTO para la vista, definido en la capa lógica
    public class UsuarioVista
    {
        public int Id_Usuario { get; set; }
        public int Id_Persona { get; set; }
        public string Usuario { get; set; }
        public bool Bloqueado { get; set; }
        public DateTime? Fecha_Bloqueo { get; set; }
        public int CambioContra { get; set; }
        public DateTime? FechaCambioContra { get; set; }
        public int Id_Rol { get; set; }
    }

    public class L_ModificarUsuario
    {
        public UsuarioVista ObtenerUsuario(int idUsuario, out string mensaje)
        {
            var usuarioDTO = D_ModificarUsuario.ObtenerUsuarioPorId(idUsuario, out mensaje);
            if (usuarioDTO == null)
                return null;

            // Mapeo de DTO de datos a DTO para vista
            return new UsuarioVista
            {
                Id_Usuario = usuarioDTO.Id_Usuario,
                Id_Persona = usuarioDTO.Id_Persona,
                Usuario = usuarioDTO.Usuario,
                Bloqueado = usuarioDTO.Bloqueado,
                Fecha_Bloqueo = usuarioDTO.Fecha_Bloqueo,
                CambioContra = usuarioDTO.CambioContra,
                FechaCambioContra = usuarioDTO.FechaCambioContra,
                Id_Rol = usuarioDTO.Id_Rol
            };
        }

        public bool ActualizarUsuario(UsuarioVista usuario, out string mensaje)
        {
            // Mapear de Vista a DTO Datos
            var usuarioDTO = new UsuarioDTO
            {
                Id_Usuario = usuario.Id_Usuario,
                Id_Persona = usuario.Id_Persona,
                Usuario = usuario.Usuario,
                Bloqueado = usuario.Bloqueado,
                Fecha_Bloqueo = usuario.Fecha_Bloqueo,
                CambioContra = usuario.CambioContra,
                FechaCambioContra = usuario.FechaCambioContra,
                Id_Rol = usuario.Id_Rol
            };

            return D_ModificarUsuario.ActualizarUsuario(usuarioDTO, out mensaje);
        }

        public bool BloquearUsuario(int idUsuario, bool bloquear, DateTime? fechaBloqueo, out string mensaje)
        {
            return D_ModificarUsuario.BloquearUsuario(idUsuario, bloquear, fechaBloqueo, out mensaje);
        }




    }
}
