import { Component, OnInit } from '@angular/core';
import {
  Conexion,
  DTOApuestaVOF,
  DTOApuestaCantidad,
  DTOApuestaEquipo,
  DTOApuestaJugador,
  DTOEnviarIdUsuario,
  DTOMostrarJugador
} from '../../models/index';
import { Api08Service } from '../../services/api08.service';
import { HttpClient } from '@angular/common/http';
import { Subject } from 'rxjs';

declare var bootbox: any;

@Component({
  selector: 'app-gestionar-apuesta',
  templateUrl: './gestionar-apuesta.component.html',
  styleUrls: [
    './gestionar-apuesta.component.css',
    '../shared/style-apuesta.component.css'
  ]
})
export class GestionarApuestaComponent implements OnInit {

  public api08: Api08Service;
  public connect: Conexion;
  public dtoUsuario: DTOEnviarIdUsuario;
  public MostrarJugadores: DTOMostrarJugador;

  public ApuestaVof: DTOApuestaVOF;
  public ApuestaCantidad: DTOApuestaCantidad;
  public ApuestaJugador: DTOApuestaJugador;
  public ApuestaEquipo: DTOApuestaEquipo;

  public ListApuestaApuestavof: DTOApuestaVOF[] = [];
  public ListApuestaApuestacantidad: DTOApuestaCantidad[] = [];
  public ListApuestaApuestajugadores: DTOApuestaJugador[] = [];
  public ListApuestaApuestaequipos: DTOApuestaEquipo[] = [];
  public ListMostrarJugadores: DTOMostrarJugador[] = [];

  public dtTriggerApuestaVof: Subject<any> = new Subject();
  public dtTriggerApuestaCantidad: Subject<any> = new Subject();
  public dtTriggerApuestaJugadores: Subject<any> = new Subject();
  public dtTriggerApuestaEquipos: Subject<any> = new Subject();
  public dtTriggerMostrarJugadores: Subject<any> = new Subject();

  public dtOptionsApuestaVof: DataTables.Settings = {};
  public dtOptionsApuestaCantidad: DataTables.Settings = {};
  public dtOptionsApuestaJugadores: DataTables.Settings = {};
  public dtOptionsApuestaEquipos: DataTables.Settings = {};
  public dtOptionsMostrarJugadores: DataTables.Settings = {};

  public actualizarOpcionVof: boolean[] = [];
  public actualizarOpcionCantidad: number[] = [];
  public actualizarOpcionJugador: number;
  public actualizarOpcionEquipo: number[] = [];

  public idLogroJugador: number;
  public display = 'none';

  constructor(private http: HttpClient) {
    this.api08 = new Api08Service(http);
    this.connect = new Conexion();
    this.dtoUsuario = new DTOEnviarIdUsuario();

    this.ApuestaVof = new DTOApuestaVOF();
    this.ApuestaCantidad = new DTOApuestaCantidad();
    this.ApuestaJugador = new DTOApuestaJugador();
    this.ApuestaEquipo = new DTOApuestaEquipo();
  }

  ngOnInit(): void {
    this.dtOptionsApuestaVof = {};
    this.dtOptionsApuestaCantidad = {};
    this.dtOptionsApuestaJugadores = {};
    this.dtOptionsApuestaEquipos = {};

    this.ObtenerApuestaVOF();
    this.ObtenerApuestaCantidad();
    this.ObtenerApuestaEquipos();
    this.ObtenerApuestaJugadores();
  }

  public ObtenerApuestaVOF() {
    this.connect.Controlador = 'obtenerapuestasvofencurso';
    const url = this.connect.GetApiApuesta() + this.connect.Controlador;
    this.dtoUsuario.IdUsuario = this.connect.IdUsuario;

    this.http
      .put<DTOApuestaVOF>(url, this.dtoUsuario, { responseType: 'json' })
      .subscribe(
        data => {
          this.dtTriggerApuestaVof.next();
          for (let i = 0; i < Object.keys(data).length; i++) {
            let apuestasVOF: DTOApuestaVOF;
            apuestasVOF = new DTOApuestaVOF();

            apuestasVOF.IdUsuario = data[i].IdLogro;

            this.ListApuestaApuestavof[i] = apuestasVOF;
          }
        },
        Error => {
          this.api08.FatalError();
        }
      );
  }

  public ObtenerApuestaCantidad() {
    this.connect.Controlador = 'obtenerapuestascantidadencurso';
    const url = this.connect.GetApiApuesta() + this.connect.Controlador;
    this.dtoUsuario.IdUsuario = this.connect.IdUsuario;

    this.http
      .put<DTOApuestaCantidad>(url, this.dtoUsuario, {
        responseType: 'json'
      })
      .subscribe(
        data => {
          this.dtTriggerApuestaCantidad.next();
          for (let i = 0; i < Object.keys(data).length; i++) {
            let apuestasCantidad: DTOApuestaCantidad;
            apuestasCantidad = new DTOApuestaCantidad();

            apuestasCantidad.IdLogro = data[i].IdLogro;

            this.ListApuestaApuestacantidad[i] = apuestasCantidad;
          }
        },
        Error => {
          this.api08.FatalError();
        }
      );
  }

  public ObtenerApuestaJugadores() {
    this.connect.Controlador = 'obtenerapuestasjugadorencurso';
    const url = this.connect.GetApiApuesta() + this.connect.Controlador;
    this.dtoUsuario.IdUsuario = this.connect.IdUsuario;

    this.http
      .put<DTOApuestaJugador>(url, this.dtoUsuario, {
        responseType: 'json'
      })
      .subscribe(
        data => {
          this.dtTriggerApuestaJugadores.next();
          for (let i = 0; i < Object.keys(data).length; i++) {
            let apuestasJugador: DTOApuestaJugador;
            apuestasJugador = new DTOApuestaJugador();

            apuestasJugador.IdLogro = data[i].IdLogro;

            this.ListApuestaApuestajugadores[i] = apuestasJugador;
          }
        },
        Error => {
          this.api08.FatalError();
        }
      );
  }

  public ObtenerApuestaEquipos() {
    this.connect.Controlador = 'obtenerapuestasequipoencurso';
    const url = this.connect.GetApiApuesta() + this.connect.Controlador;
    this.dtoUsuario.IdUsuario = this.connect.IdUsuario;

    this.http
      .put<DTOApuestaEquipo>(url, this.dtoUsuario, { responseType: 'json' })
      .subscribe(
        data => {
          this.dtTriggerApuestaEquipos.next();
          for (let i = 0; i < Object.keys(data).length; i++) {
            let logrosEquipo: DTOApuestaEquipo;
            logrosEquipo = new DTOApuestaEquipo();

            logrosEquipo.IdLogro = data[i].IdLogro;

            this.ListApuestaApuestaequipos[i] = logrosEquipo;
          }
        },
        Error => {
          this.api08.FatalError();
        }
      );
  }

  public ObtenerListaJugadoresPartido() {
    this.connect.Controlador = 'obtenerJugadores';
    const url = this.connect.GetApiJugador() + this.connect.Controlador;

    this.http
      .get<DTOMostrarJugador>(url, {
        responseType: 'json'
      })
      .subscribe(
        data => {
          this.dtTriggerMostrarJugadores.next();
          for (let i = 0; i < Object.keys(data).length; i++) {
            let listaJugadores: DTOMostrarJugador;
            listaJugadores = new DTOMostrarJugador();

            listaJugadores.Id = data[i].Id;
            listaJugadores.Nombre = data[i].Nombre;
            listaJugadores.Apellido = data[i].Apellido;

            this.ListMostrarJugadores[i] = listaJugadores;
          }
        },
        Error => {
          this.api08.FatalError();
        }
      );
  }

  public ActualizarApuestaVof(IdLogro, actualizarvof: boolean) {
    if (actualizarvof) {
      this.api08.ActualiarApuestaVof(IdLogro, actualizarvof);
    } else {
      bootbox.alert('Debes seleccionar una opción Valida');
    }
  }

  public ActualizarApuestaCantidad(IdLogro, actualizarCantidad: number) {
    if (actualizarCantidad) {
      this.api08.ActualiarApuestaCantidad(IdLogro, actualizarCantidad);
    } else {
      bootbox.alert('Debes Ingresar una Cantidad Valida');
    }
  }

  public ActualizarApuestaJugador(IdJugador: number) {
    if (IdJugador) {
      this.api08.ActualiarApuestaJugador(this.idLogroJugador, IdJugador);
      this.closeModalJuagdores();
    } else {
      bootbox.alert('Debes escoger un jugador Valido');
    }
  }

  public ActualizarApuestaEquipo(IdLogro, IdEquipo: number) {
    if (IdEquipo) {
      this.api08.ActualiarApuestaEquipo(IdLogro, IdEquipo);
    } else {
      bootbox.alert('Debes escoger un equipo Valido');
    }
  }

  public openModaljugadores(idLogro) {
    this.idLogroJugador = idLogro;
    this.ObtenerListaJugadoresPartido();
    this.display = 'block';
  }

  public closeModalJuagdores() {
    this.display = 'none';
  }
}
