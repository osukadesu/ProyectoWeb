import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { ClienteConsultaComponent } from './hotel/cliente/cliente-consulta/cliente-consulta.component';
import { ClienteRegistroComponent } from './hotel/cliente/cliente-registro/cliente-registro.component';
import { ClienteGestionComponent } from './hotel/cliente/cliente-gestion/cliente-gestion.component';
import { AdministracionComponent } from './hotel/administracion/administracion.component';
import { EmpleadoRegistroComponent } from './hotel/empleado/empleado-registro/empleado-registro.component';
import { EmpleadoConsultaComponent } from './hotel/empleado/empleado-consulta/empleado-consulta.component';
import { EmpleadoGestionComponent } from './hotel/empleado/empleado-gestion/empleado-gestion.component';
import { FacturaRegistroComponent } from './hotel/factura/factura-registro/factura-registro.component';
import { FacturaConsultaComponent } from './hotel/factura/factura-consulta/factura-consulta.component';
import { FacturaGestionComponent } from './hotel/factura/factura-gestion/factura-gestion.component';
import { HabitacionRegistroComponent } from './hotel/habitacion/habitacion-registro/habitacion-registro.component';
import { HabitacionConsultaComponent } from './hotel/habitacion/habitacion-consulta/habitacion-consulta.component';
import { HabitacionGestionComponent } from './hotel/habitacion/habitacion-gestion/habitacion-gestion.component';
import { FormsModule } from '@angular/forms';

const routes: Routes = [
  { path: 'home', component: HomeComponent},
  { path: 'clienteregistro', component: ClienteRegistroComponent},
  { path: 'clienteconsulta', component: ClienteConsultaComponent },
  { path: 'clientegestion', component: ClienteGestionComponent },
  { path: 'empleadoregistro', component: EmpleadoRegistroComponent},
  { path: 'empleadoconsulta', component: EmpleadoConsultaComponent },
  { path: 'empleadogestion', component: EmpleadoGestionComponent },
  { path: 'facturaregistro', component: FacturaRegistroComponent},
  { path: 'facturaconsulta', component: FacturaConsultaComponent },
  { path: 'facturagestion', component: FacturaGestionComponent },
  { path: 'habitacionregistro', component: HabitacionRegistroComponent},
  { path: 'habitacionconsulta', component: HabitacionConsultaComponent },
  { path: 'habitaciongestion', component: HabitacionGestionComponent },
  { path: 'administracion', component: AdministracionComponent },
  { path: '', component: HomeComponent}
];



@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    FormsModule,
    RouterModule.forRoot(routes)
  ],
  exports:[RouterModule]
})
export class AppRoutingModule { }