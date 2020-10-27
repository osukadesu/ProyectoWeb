import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { ClienteConsultaComponent } from './hotel/cliente/cliente-consulta/cliente-consulta.component';
import { FooterComponent } from './footer/footer.component';
import { AppRoutingModule } from './app-routing.module';
import { AdministracionComponent } from './hotel/administracion/administracion.component';
import { ClienteGestionComponent } from './hotel/cliente/cliente-gestion/cliente-gestion.component';
import { ClienteRegistroComponent } from './hotel/cliente/cliente-registro/cliente-registro.component';
import { HabitacionConsultaComponent } from './hotel/habitacion/habitacion-consulta/habitacion-consulta.component';
import { HabitacionRegistroComponent } from './hotel/habitacion/habitacion-registro/habitacion-registro.component';
import { HabitacionGestionComponent } from './hotel/habitacion/habitacion-gestion/habitacion-gestion.component';
import { FacturaConsultaComponent } from './hotel/factura/factura-consulta/factura-consulta.component';
import { FacturaRegistroComponent } from './hotel/factura/factura-registro/factura-registro.component';
import { FacturaGestionComponent } from './hotel/factura/factura-gestion/factura-gestion.component';
import { EmpleadoConsultaComponent } from './hotel/empleado/empleado-consulta/empleado-consulta.component';
import { EmpleadoRegistroComponent } from './hotel/empleado/empleado-registro/empleado-registro.component';
import { EmpleadoGestionComponent } from './hotel/empleado/empleado-gestion/empleado-gestion.component';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    ClienteConsultaComponent,
    ClienteRegistroComponent,
    ClienteGestionComponent,
    FooterComponent,
    AdministracionComponent,
    HabitacionConsultaComponent,
    HabitacionRegistroComponent,
    HabitacionGestionComponent,
    FacturaConsultaComponent,
    FacturaRegistroComponent,
    FacturaGestionComponent,
    EmpleadoConsultaComponent,
    EmpleadoRegistroComponent,
    EmpleadoGestionComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    CommonModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
    ]),
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
