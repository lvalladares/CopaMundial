﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Comun.Entidades.Fabrica;
using CopaMundialAPI.Comun.Excepciones;
using CopaMundialAPI.Fuente_de_Datos.DAO.Interfaces;
using Npgsql;

namespace CopaMundialAPI.Fuente_de_Datos.DAO
{
    public class DAOApuestaJugador : DAO, IDAOApuesta
    {
        public void Actualizar(Entidad entidad)
        {
            ApuestaJugador apuesta = entidad as ApuestaJugador;

            StoredProcedure("editarapuestajugador(@idlogro, @idusuario, @apuesta)");

            AgregarParametro("idlogro", apuesta.Logro.Id);
            AgregarParametro("idusuario", apuesta.Usuario.Id);
            AgregarParametro("apuesta", apuesta.Respuesta.Id);

            EjecutarQuery();
        }

        public void Agregar(Entidad entidad)
        {
            Conectar();

            ApuestaJugador apuesta = entidad as ApuestaJugador;

            StoredProcedure("agregarapuestajugador(@idlogro, @idusuario, @apuesta)");

            AgregarParametro("idlogro", apuesta.Logro.Id);
            AgregarParametro("idusuario", apuesta.Usuario.Id);
            AgregarParametro("apuesta", apuesta.Respuesta.Id);

            EjecutarQuery();
        }

        public void Eliminar(Entidad entidad)
        {
            ApuestaJugador apuesta = entidad as ApuestaJugador;

            StoredProcedure("eliminarapuesta(@idlogro, @idusuario)");

            AgregarParametro("idlogro", apuesta.Logro.Id);
            AgregarParametro("idusuario", apuesta.Usuario.Id);

            EjecutarQuery();
        }

        public List<Entidad> ObtenerApuestasEnCurso(Entidad usuario)
        {
            List<Entidad> apuestasEnCurso = new List<Entidad>();

            ApuestaJugador apuesta;

            LogroJugador logro;

            Jugador jugador;

            try
            {
                Usuario apostador = usuario as Usuario;

                Conectar();

                StoredProcedure("obtenerapuestasjugadorencurso(@idusuario)");

                AgregarParametro("idusuario", usuario.Id);

                EjecutarReader();

                for (int i = 0; i < cantidadRegistros; i++)
                {
                    apuesta = FabricaEntidades.CrearApuestaJugador();

                    logro = FabricaEntidades.CrearLogroJugador();

                    jugador = FabricaEntidades.CrearJugador();

                    logro.Id = GetInt(i, 0);

                    logro.Logro = GetString(i, 1);

                    jugador.Id = GetInt(i, 2);

                    jugador.Nombre = GetString(i, 3);

                    jugador.Apellido = GetString(i, 4);

                    apuesta.Estado = GetString(i, 5);

                    apuesta.Fecha = GetDateTime(i, 6);

                    apuesta.Logro = logro;

                    apuesta.Respuesta = jugador;

                    apuesta.Usuario = apostador;

                    apuestasEnCurso.Add(apuesta);

                }


                return apuestasEnCurso;

            }
            catch (InvalidCastException exc)
            {
                Desconectar();
                throw exc;
            }
        }

        public List<Entidad> ObtenerApuestasFinalizadas(Entidad usuario)
        {
            throw new NotImplementedException();
        }

        public List<Entidad> ObtenerTodos()
        {
            throw new NotImplementedException();
        }

        public int VerificarApuestaExiste(Entidad apuesta)
        {
            Conectar();

            ApuestaJugador apuestajugador = apuesta as ApuestaJugador;

            StoredProcedure("verificarapuestaexiste(@idusuario, @idlogro)");

            AgregarParametro("idusuario", apuestajugador.Usuario.Id);
            AgregarParametro("idlogro", apuestajugador.Logro.Id);

            EjecutarReader();

            int count = GetInt(0, 0);


            return count;
        }
    
    }
}