import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule, HTTP_INTERCEPTORS } from  '@angular/common/http'

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { EmpleadosComponent } from './pages/empleados/empleados.component';
import { AgregarComponent } from './pages/empleados/agregar/agregar.component';
import { EditarComponent } from './pages/empleados/editar/editar.component';
import { LoadingComponent } from './Shared/loading/loading.component';
import { LoadingInterceptor } from './Interceptors/loading.interceptor';
import { ApiInterceptor } from './Interceptors/api.interceptor';
import { RouterModule } from '@angular/router';
import { ErrorsInterceptor } from './Interceptors/errors.interceptor';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ErrorComponent } from './Shared/error/error.component';
import { DetalleComponent } from './pages/empleados/detalle/detalle.component';

@NgModule({
  declarations: [
    AppComponent,
    EmpleadosComponent,
    AgregarComponent,
    EditarComponent,
    LoadingComponent,
    ErrorComponent,
    DetalleComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    RouterModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [
    {provide: HTTP_INTERCEPTORS, useClass: LoadingInterceptor, multi: true},
    {provide: HTTP_INTERCEPTORS, useClass: ApiInterceptor, multi: true},
    {provide: HTTP_INTERCEPTORS, useClass: ErrorsInterceptor, multi: true},
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
