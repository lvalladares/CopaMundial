﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Comun.Entidades.Fabrica;
using CopaMundialAPI.Servicios.DTO.Apuestas;
using CopaMundialAPI.Servicios.Fabrica;

namespace CopaMundialAPI.Servicios.Traductores.Apuestas
{
    public class TraductorApuestaCantidad : TraductorGenerico<DTOApuestaCantidad, ApuestaCantidad>
    {
        public override DTOApuestaCantidad CrearDto(ApuestaCantidad entidad)
        {
            DTOApuestaCantidad dto = FabricaDTO.CrearDtoApuestaCantidad();

            dto.IdLogro = entidad.Logro.Id;
            dto.IdUsuario = entidad.Usuario.Id;
            dto.ApuestaUsuario = entidad.Respuesta;
            dto.Estado = entidad.Estado;

            return dto;
        }

        public override ApuestaCantidad CrearEntidad(DTOApuestaCantidad dto)
        {
            ApuestaCantidad entidad = FabricaEntidades.CrearApuestaCantidad();

            entidad.Logro.Id = dto.IdLogro;
            entidad.Usuario.Id = dto.IdUsuario;
            entidad.Respuesta = dto.ApuestaUsuario;
            entidad.Fecha = DateTime.Now.ToShortDateString();

            return entidad;
        }

        public override List<DTOApuestaCantidad> CrearListaDto(List<ApuestaCantidad> entidades)
        {
            List<DTOApuestaCantidad> dtos = new List<DTOApuestaCantidad>();

            foreach (ApuestaCantidad entidad in entidades)
            {
                dtos.Add(CrearDto(entidad));
            }

            return dtos;
        }

        public override List<ApuestaCantidad> CrearListaEntidades(List<DTOApuestaCantidad> dtos)
        {
            throw new NotImplementedException();
        }
    }
}