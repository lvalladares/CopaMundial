﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CopaMundialAPI.Servicios.Traductores.Apuestas;
using CopaMundialAPI.Servicios.Traductores.Partidos;
using CopaMundialAPI.Servicios.Traductores.Ciudades;

namespace CopaMundialAPI.Servicios.Traductores.Fabrica
{
    public class FabricaTraductor
    {
        public static TraductorApuestaCantidad CrearTraductorApuestaCantidad() 
        {
            return new TraductorApuestaCantidad();
        }

        public static TraductorApuestaJugador CrearTraductorApuestaJugador()
        {
            return new TraductorApuestaJugador();
        }

        public static TraductorApuestaVOF CrearTraductorApuestaVoF()
        {
            return new TraductorApuestaVOF();
        }

        public static TraductorApuestaEquipo CrearTraductorApuestaEquipo()
        {
            return new TraductorApuestaEquipo();
        }

        public static TraductorListarProximosPartidos CrearTraductorListarProximosPartidos()
        {
            return new TraductorListarProximosPartidos();
        }

        /// <summary>
        /// Metodo con el cual se instancia un objeto de tipo TraductorCiudad
        /// </summary>
        /// <returns></returns>
        public static TraductorCiudad CrearTraductorCiudad ( )
        {
            return new TraductorCiudad ( );
        }
       
    }
}