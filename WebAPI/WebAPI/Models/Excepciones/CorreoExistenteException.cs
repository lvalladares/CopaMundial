﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models.Excepciones
{
    public class CorreoExistenteException : Exception
    {
        private readonly string _mensaje = "Correo existente.";
        private readonly int _codigoError = 20001;
        private string _correo;
        private DateTime _errorDate;


        public CorreoExistenteException(string correo)
        {
            _correo = correo;
            _errorDate = DateTime.Now;
        }

        
        public string Correo
        {
            get { return _correo; }
        }

        public DateTime ErrorDate
        {
            get { return _errorDate; }
        }

        public new string Message
        {
            get { return _mensaje; }
        }

        public int CodigoError
        {
            get { return _codigoError; }
        }
    }
}