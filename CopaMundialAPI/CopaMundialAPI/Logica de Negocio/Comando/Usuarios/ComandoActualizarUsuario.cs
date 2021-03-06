﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Fuente_de_Datos.DAO.Interfaces;
using CopaMundialAPI.Fuente_de_Datos.Fabrica;

namespace CopaMundialAPI.Logica_de_Negocio.Comando.Usuarios
{
    /// <summary>
    /// Comando que se encarga de actualizar los datos de perfil de un usuario
    /// </summary>
    public class ComandoActualizarUsuario : Comando
    {

        public ComandoActualizarUsuario(Entidad usuario)
        {
            Entidad = usuario;
        }

        public override void Ejecutar()
        {
            IDAOUsuario dao = FabricaDAO.CrearDAOUsuario();
            dao.Actualizar(Entidad);
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