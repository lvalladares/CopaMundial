﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Comun.Entidades.Fabrica;
using CopaMundialAPI.Fuente_de_Datos.DAO.Interfaces;
using Npgsql;
using CopaMundialAPI.Comun.Excepciones;

namespace CopaMundialAPI.Fuente_de_Datos.DAO
{
    public class DAOJugador : DAO, IDAOJugador
    {
        /// <summary>
        /// Metodo ActivarJugador , activa jugador
        /// </summary>
        /// <param name="objeto">El objeto que se desea activar</param>
        public void ActivarJugador(Entidad entidad)
        {
            try
            {
                Jugador jugador = entidad as Jugador;

                Conectar();

                StoredProcedure("activarJugador(@_id)");

                AgregarParametro("_id", jugador.Id);


                EjecutarQuery();
            }
            catch(NpgsqlException exc)
            {
                Desconectar();
                throw new BaseDeDatosException(exc, "Error al activar jugador");
            }

        }

        /// <summary>
        /// Metodo DesactivarJugador , desactiva jugador
        /// </summary>
        /// <param name="objeto">El objeto que se desea desactivar</param>
        public void DesactivarJugador(Entidad entidad)
        {
            try
            {
                Jugador jugador = entidad as Jugador;

                Conectar();

                StoredProcedure("desactivarJugador(@_id)");

                AgregarParametro("_id", jugador.Id);


                EjecutarQuery();
            }
            catch (NpgsqlException exc)
            {
                Desconectar();
                throw new BaseDeDatosException(exc, "Error al desactivar jugador");
            }
            
        }

        public void Actualizar(Entidad entidad)
        {
            try
            {
                Jugador jugador = entidad as Jugador;

                Conectar();

                StoredProcedure("editarJugador(@_id,@_nombre,@_apellido,@_fechaNacimiento,@_lugarNacimiento,@_peso,@_altura,@_posicion,@_numero,@_capitan)");

                AgregarParametro("_id", jugador.Id);
                AgregarParametro("_nombre", jugador.Nombre);
                AgregarParametro("_apellido", jugador.Apellido);
                AgregarParametro("_fechaNacimiento", jugador.FechaNacimiento);
                AgregarParametro("_lugarNacimiento", jugador.LugarNacimiento);
                AgregarParametro("_peso", jugador.Peso);
                AgregarParametro("_altura", jugador.Altura);
                AgregarParametro("_posicion", jugador.Posicion);
                AgregarParametro("_numero", jugador.Numero);
                AgregarParametro("_capitan", jugador.Equipo);

                EjecutarQuery();
            }
            catch (NpgsqlException exc)
            {
                Desconectar();
                throw new BaseDeDatosException(exc, "Error al modificar jugador");
            }
            
        }

        public void Eliminar(Entidad entidad)
        {
            throw new NotImplementedException();
        }

        public List<Entidad> ObtenerTodos()
        {
            throw new NotImplementedException();
        }

        public List<Entidad> ObtenerJugadores()
        {
            try
            {
                List<Entidad> jugadores = new List<Entidad>();
                Jugador jugador;

                Conectar();

                StoredProcedure("consultarJugadores()");

                EjecutarReader();

                for (int i = 0; i < cantidadRegistros; i++)
                {
                    jugador = FabricaEntidades.CrearJugador();

                    jugador.Id = GetInt(i, 0);
                    jugador.Nombre = GetString(i, 1);
                    jugador.Apellido = GetString(i, 2);
                    jugador.FechaNacimiento = GetString(i, 3);
                    jugador.LugarNacimiento = GetString(i, 4);
                    jugador.Peso = GetDecimal(i, 5);
                    jugador.Altura = GetDecimal(i, 6);
                    jugador.Posicion = GetString(i, 7);
                    jugador.Numero = GetDecimal(i, 8);
                    jugador.Equipo.Pais = GetString(i, 9);
                    jugador.Capitan = GetBool(i, 10);

                    jugadores.Add(jugador);
                }

                return jugadores;
            }
            catch (NpgsqlException exc)
            {
                Desconectar();
                throw new BaseDeDatosException(exc, "Error al obtener todos los jugadores");
            }
            
        }

        public List<Entidad> ObtenerJugadoresActivo()
        {
            try
            {
                List<Entidad> jugadores = new List<Entidad>();
                Jugador jugador;

                Conectar();

                StoredProcedure("consultarJugadoresActivo()");

                EjecutarReader();

                for (int i = 0; i < cantidadRegistros; i++)
                {
                    jugador = FabricaEntidades.CrearJugador();

                    jugador.Id = GetInt(i, 0);
                    jugador.Nombre = GetString(i, 1);
                    jugador.Apellido = GetString(i, 2);
                    jugador.FechaNacimiento = GetString(i, 3);
                    jugador.LugarNacimiento = GetString(i, 4);
                    jugador.Peso = GetDecimal(i, 5);
                    jugador.Altura = GetDecimal(i, 6);
                    jugador.Posicion = GetString(i, 7);
                    jugador.Numero = GetDecimal(i, 8);
                    jugador.Equipo.Pais = GetString(i, 9);
                    jugador.Capitan = GetBool(i, 10);

                    jugadores.Add(jugador);
                }

                return jugadores;
            }
            catch (NpgsqlException exc)
            {
                Desconectar();
                throw new BaseDeDatosException(exc, "Error al obtener jugadores activos");
            }
        }

        public List<Entidad> ObtenerJugadoresInactivo()
        {
            try
            {
                List<Entidad> jugadores = new List<Entidad>();
                Jugador jugador;

                Conectar();

                StoredProcedure("consultarJugadoresInactivo()");

                EjecutarReader();

                for (int i = 0; i < cantidadRegistros; i++)
                {
                    jugador = FabricaEntidades.CrearJugador();

                    jugador.Id = GetInt(i, 0);
                    jugador.Nombre = GetString(i, 1);
                    jugador.Apellido = GetString(i, 2);
                    jugador.FechaNacimiento = GetString(i, 3);
                    jugador.LugarNacimiento = GetString(i, 4);
                    jugador.Peso = GetDecimal(i, 5);
                    jugador.Altura = GetDecimal(i, 6);
                    jugador.Posicion = GetString(i, 7);
                    jugador.Numero = GetDecimal(i, 8);
                    jugador.Equipo.Pais = GetString(i, 9);
                    jugador.Capitan = GetBool(i, 10);

                    jugadores.Add(jugador);
                }

                return jugadores;
            }
            catch (NpgsqlException exc)
            {
                Desconectar();
                throw new BaseDeDatosException(exc, "Error al obtener jugadores inactivos");
            }
            
        }

        public Entidad ObtenerJugadorId(Entidad entidad)
        {
            try
            {
                Jugador jugador = entidad as Jugador;

                Conectar();

                StoredProcedure("consultarJugadorId(@_id)");

                AgregarParametro("_id", jugador.Id);

                EjecutarReader();

                for (int i = 0; i < cantidadRegistros; i++)
                {
                    jugador = FabricaEntidades.CrearJugador();

                    jugador.Id = GetInt(i, 0);
                    jugador.Nombre = GetString(i, 1);
                    jugador.Apellido = GetString(i, 2);
                    jugador.FechaNacimiento = GetString(i, 3);
                    jugador.LugarNacimiento = GetString(i, 4);
                    jugador.Peso = GetDecimal(i, 5);
                    jugador.Altura = GetDecimal(i, 6);
                    jugador.Posicion = GetString(i, 7);
                    jugador.Numero = GetDecimal(i, 8);
                    jugador.Equipo.Pais = GetString(i, 9);
                    jugador.Capitan = GetBool(i, 10);
                }

                return jugador;
            }
            catch (NpgsqlException exc)
            {
                Desconectar();
                throw new BaseDeDatosException(exc, "Error al obtener jugador por id");
            }
        }

        public void Agregar(Entidad entidad)
        {
            try
            {
                Jugador jugador = entidad as Jugador;

                Conectar();

                StoredProcedure("insertarJugador(@_nombre,@_apellido,to_date(@_fechaNacimiento, 'DD-MM-YY'),@_lugarNacimiento,@_peso,@_altura,@_posicion,@_numero,@_equipo)");

                AgregarParametro("_nombre", jugador.Nombre);
                AgregarParametro("_apellido", jugador.Apellido);
                AgregarParametro("_fechaNacimiento", jugador.FechaNacimiento);
                AgregarParametro("_lugarNacimiento", jugador.LugarNacimiento);
                AgregarParametro("_peso", jugador.Peso);
                AgregarParametro("_altura", jugador.Altura);
                AgregarParametro("_posicion", jugador.Posicion);
                AgregarParametro("_numero", jugador.Numero);
                AgregarParametro("_equipo", jugador.Equipo.Pais);

                EjecutarQuery();
            }
            catch (NpgsqlException exc)
            {
                Desconectar();
                throw new BaseDeDatosException(exc, "Error al agregar jugador");
            }
        }
    }
}