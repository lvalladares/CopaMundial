import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { Modulo09RoutingModule } from './modulo09-routing.module';
import { EstgeneralComponent } from './estgeneral/estgeneral.component';
import { EstpartidoComponent } from './estpartido/estpartido.component';
import { EstjugadorComponent } from './estjugador/estjugador.component';
import { PredequipoComponent } from './predequipo/predequipo.component';
import { PredjugadorComponent } from './predjugador/predjugador.component';
import { GenestjugComponent } from './genestjug/genestjug.component';
import { EstequiposComponent } from './estequipos/estequipos.component';
import { HttpClientModule } from '@angular/common/http';
import { HttpModule } from '@angular/http';
import { FormsModule } from '@angular/forms';


@NgModule({
  imports: [
    CommonModule,
    Modulo09RoutingModule,
    HttpClientModule,
    HttpModule,
    FormsModule
    
  ],
  declarations: [EstgeneralComponent, EstpartidoComponent, EstjugadorComponent, PredequipoComponent, PredjugadorComponent, GenestjugComponent, EstequiposComponent]
})
export class Modulo09Module { }
