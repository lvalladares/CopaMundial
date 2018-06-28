﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Fuente_de_Datos.DAO;
using CopaMundialAPI.Fuente_de_Datos.Fabrica;
using CopaMundialAPI.Comun.Excepciones;

namespace CopaMundialAPI.Logica_de_Negocio.Comando.Apuestas
{
    public class ComandoVerificarApuestaCantidadExiste : Comando
    {
        DAOApuestaCantidad _dao;
        Entidad _apuesta;

        public ComandoVerificarApuestaCantidadExiste(Entidad apuesta)
        {
            _apuesta = apuesta;
            _dao = FabricaDAO.CrearDAOApuestaCantidad();
        }

        public override void Ejecutar()
        {
            int count = _dao.VerificarApuestaExiste(_apuesta);

            if (count > 0)
                throw new ApuestaRepetidaException();
        }

        public override Entidad GetEntidad()
        {
            throw new NotImplementedException();
        }

        public override List<Entidad> GetEntidades()
        {
            throw new NotImplementedException();
        }
    }
}