﻿using System.Collections.Generic;
using CopaMundialAPI.Comun.Entidades;
using CopaMundialAPI.Comun.Entidades.Fabrica;
using CopaMundialAPI.Comun.Excepciones;
using CopaMundialAPI.Fuente_de_Datos.DAO;
using CopaMundialAPI.Fuente_de_Datos.Fabrica;
using CopaMundialAPI.Logica_de_Negocio.Comando;
using CopaMundialAPI.Logica_de_Negocio.Fabrica;
using CopaMundialAPI.Servicios.DTO.Logros;
using CopaMundialAPI.Servicios.Fabrica;
using CopaMundialAPI.Servicios.Traductores.Logros;
using CopaMundialAPI.Servicios.Traductores.Fabrica;
using CopaMundialAPI.Presentacion.Controllers;
using NUnit.Framework;
using System.Net.Http;
using System.Net;

namespace PruebasCopaMundialAPI.Modulo_7
{
    public class PruebasLogroVF
    {


        private DAO dao;
        private Comando comando;
        private Entidad respuesta;
        private List<Entidad> _respuestas;
        private LogrosController controller;

        [SetUp]
        public void SetUp()
        {
            dao = FabricaDAO.CrearDAOLogroVF();
            dao.StoredProcedure("AsignarLogroPU(500,'PruebaLogroVF',1,1)");
            dao.EjecutarQuery();
            dao.Conectar();
            controller = new LogrosController();
            controller.Request = new HttpRequestMessage();

        }


        /// <summary>
        /// Metodo que prueba el resultado de exito
        /// del dao de Agregar logroVF
        /// </summary>
        [Test]
        public void PruebaDaoLogroVFAgregar()
        {

            LogroVoF logro = FabricaEntidades.CrearLogroVoF();
            Partido partido = FabricaEntidades.CrearPartido();
            logro.Partido = partido;
            logro.Partido.Id = 14; //cambiar por 1
            logro.IdTipo = TipoLogro.vof;
            logro.Logro = "Logro vf Prueba Agregar";


            ((DAOLogroVF)dao).Agregar(logro);
            respuesta = FabricaEntidades.CrearLogroVoF();

            respuesta = ((DAOLogroVF)dao).ObtenerLogroPorId(logro);

            Assert.IsNotNull(respuesta);
        }

        /// <summary>
        /// Metodo que prueba el resultado de exito del 
        /// comando logroEquipoAgregar
        /// </summary>
        [Test]
        public void PruebaComandoLogroVFAgregar()
        {
            
            LogroVoF logro = FabricaEntidades.CrearLogroVoF();
            Partido partido = FabricaEntidades.CrearPartido();

            logro.Partido = partido;
            logro.Partido.Id = 14; //cambiar a 1
            logro.IdTipo = TipoLogro.vof;
            logro.Logro = "Logro vf Prueba Comando agregar";

            comando = FabricaComando.CrearComandoAgregarLogroVF(logro);
            comando.Ejecutar();
            respuesta = comando.GetEntidad();
            Assert.IsNotNull(respuesta);

        }

        /// <summary>
        /// Metodo que prueba la traduccion de una entidad 
        /// a un dtoLogroVF
        /// </summary>
        [Test]
        public void PruebaTraductorLogroVFDto()
        {
            TraductorLogroVF traductor = FabricaTraductor.CrearTraductorLogroVF();
            LogroVoF logro = FabricaEntidades.CrearLogroVoF();
            DTOLogroVF dtoLogro = FabricaDTO.CrearDTOLogroVF();

            Partido partido = FabricaEntidades.CrearPartido();
            logro.Partido = partido;
            logro.Partido.Id = 1;
            logro.IdTipo = TipoLogro.vof;
            logro.Logro = "Logro vf Prueba Traductor";

            dtoLogro = traductor.CrearDto(logro);

            Assert.AreEqual(1, dtoLogro.IdPartido);

        }

        /// <summary>
        /// Metodo que prueba la traduccion de un dtoLogroVF
        /// a una entidad logroEquipo
        /// </summary>
        [Test]
        public void PruebaTraductorLogroVFEntidad()
        {
            TraductorLogroVF traductor = FabricaTraductor.CrearTraductorLogroVF();
            LogroVoF logro = FabricaEntidades.CrearLogroVoF();
            DTOLogroVF dtoLogro = FabricaDTO.CrearDTOLogroVF();

            dtoLogro.IdPartido = 1;
            dtoLogro.LogroVF = "Prueba de dto a entidad logro vf";
            dtoLogro.TipoLogro = (int)TipoLogro.vof;

            logro = (LogroVoF)traductor.CrearEntidad(dtoLogro);

            Assert.AreEqual(1, logro.Partido.Id);

        }

        /// <summary>
        /// Metodo que prueba la respuesta exitosa de
        ///del metodo agregarLogroVF del 
        ///LogroCotroller
        /// </summary>
        [Test]
        public void PruebaControllerAgregarLogroVF()
        {
            DTOLogroVF dtoLogro = FabricaDTO.CrearDTOLogroVF();
            dtoLogro.IdPartido = 14; //cambiar a 1
            dtoLogro.LogroVF = "Prueba controller Agregar logro VF";
            dtoLogro.TipoLogro = (int)TipoLogro.vof;

            Assert.AreEqual(HttpStatusCode.OK, controller.AgregarLogroVF(dtoLogro).StatusCode);

        }

        /// <summary>
        /// Metodo que prueba el resultado de exito 
        /// del dao ObtenerLogrosPendientes
        /// </summary>
        [Test]
        public void PruebaDaoObtenerLogrosVFPendientes()
        {
            LogroVoF logro = FabricaEntidades.CrearLogroVoF();
            Partido partido = FabricaEntidades.CrearPartido();
            partido.Id = 14; //cambiar por 1
            logro.Partido = partido;
            logro.IdTipo = TipoLogro.vof;
            logro.Logro = "Logro vf Prueba dao obtener logros";

            ((DAOLogroVF)dao).Agregar(logro);

            _respuestas = ((DAOLogroVF)dao).ObtenerLogrosPendientes(partido);
            Assert.IsNotNull(_respuestas);
        }


        /// <summary>
        /// Metodo que prueba el resultado de la
        /// excepcion LogrosPendientesNoExisteException
        /// en el Dao
        /// </summary>
        [Test]
        public void PruebaDaoObtenerLogrosVFPendientesException()
        {

            Partido partido = FabricaEntidades.CrearPartido();
            partido.Id = 15; //cambiar numero

            Assert.Throws<LogrosPendientesNoExisteException>(() => ((DAOLogroVF)dao).ObtenerLogrosPendientes(partido));
        }

        /// <summary>
        /// Metodo que prueba el resultado de exito del 
        /// comando ObtenerLogrosEquipoPendientes
        /// </summary>
        [Test]
        public void PruebaComandoObtenerLogrosVFPendientes()
        {
            LogroVoF logro = FabricaEntidades.CrearLogroVoF();
            Partido partido = FabricaEntidades.CrearPartido();
            partido.Id = 14; //cambiar a 1
            logro.Partido = partido;
            logro.IdTipo = TipoLogro.vof;
            logro.Logro = "Logro vf Prueba pendientes";

            ((DAOLogroVF)dao).Agregar(logro);

            comando = FabricaComando.CrearComandoObtenerLogrosVFPendientes(partido);
            comando.Ejecutar();
            _respuestas = comando.GetEntidades();
            Assert.AreNotEqual(0, _respuestas.Count);

        }

        /// <summary>
        /// Metodo que prueba el resultado de la
        /// excepcion LogrosPendientesNoExisteException en el
        /// comando
        /// </summary>
        [Test]
        public void PruebaCmdObtenerLogrosVFPendientesException()
        {
          
            Partido partido = FabricaEntidades.CrearPartido();
            partido.Id = 15; //cambiar numero

            comando = FabricaComando.CrearComandoObtenerLogrosVFPendientes(partido);
            Assert.Throws<LogrosPendientesNoExisteException>(() => comando.Ejecutar());
            
        }

        [TearDown]
        public void TearDown()
        {
            dao.Desconectar();
            dao = null;
            comando = null;
            respuesta = null;
            _respuestas = null;

        }
    }
}
