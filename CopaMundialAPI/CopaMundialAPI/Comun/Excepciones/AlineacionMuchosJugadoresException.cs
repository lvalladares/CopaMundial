﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CopaMundialAPI.Comun.Excepciones
{
    public class AlineacionMuchosJugadoresException : ExcepcionPersonalizada
    {
        public AlineacionMuchosJugadoresException(string mensaje)
        {
            Mensaje = mensaje;
        }
    }
}