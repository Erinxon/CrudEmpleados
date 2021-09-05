import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AgregarComponent } from './pages/empleados/agregar/agregar.component';
import { DetalleComponent } from './pages/empleados/detalle/detalle.component';
import { EditarComponent } from './pages/empleados/editar/editar.component';
import { EmpleadosComponent } from './pages/empleados/empleados.component';

const routes: Routes = [
  {path: '', component: EmpleadosComponent},
  {path: 'agregar', component: AgregarComponent},
  {path: 'editar/:id', component: EditarComponent},
  {path: 'detalle/:id', component: DetalleComponent},
  {path: '**', redirectTo: ''}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
