using Datos;
using Datos.DTOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class L_ListarPreguntas
    {
        public List<PreguntaVista> ListarPreguntas()
        {
            D_ListarPreguntas datos = new D_ListarPreguntas();
            List<PreguntaDTO> listaDTO = datos.ListarPreguntas();

            List<PreguntaVista> listaVista = listaDTO.Select(dto => new PreguntaVista
            {
                Id = dto.IdPregunta,
                Pregunta = dto.Pregunta
            }).ToList();

            return listaVista;
        }
    }
}