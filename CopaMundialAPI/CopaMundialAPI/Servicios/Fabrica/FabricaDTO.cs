﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CopaMundialAPI.Servicios.DTO.Apuestas;
using CopaMundialAPI.Servicios.DTO.Ciudades;


namespace CopaMundialAPI.Servicios.Fabrica
{
    public class FabricaDTO
    {
        public static DTOApuestaVOF CrearDtoApuestaVOF()
        {
            return new DTOApuestaVOF();
        }

        public static DTOApuestaCantidad CrearDtoApuestaCantidad()
        {
            return new DTOApuestaCantidad();
        }

        public static DTOApuestaJugador CrearDtoApuestaJugador()
        {
            return new DTOApuestaJugador();
        }

        public static DTOCiudad CrearDTOCiudad (string nombre, int habitantes, string descripcion, string nombreIngles, string descripcionIngles, byte[] imagen)
        {
            return new DTOCiudad (nombre,habitantes,descripcion,nombreIngles,descripcionIngles,imagen);
        }
    }
}