import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { ApiResponse } from '../ApiResponse/ApiResponse';
import { Empleado } from '../models/Empleado';
import { UpdateEmpleadoModel } from '../models/UpdateEmpleadoModel';

@Injectable({
  providedIn: 'root'
})
export class EmpledoService {

  constructor(private http: HttpClient) { }

  getEmpleados(pageNumber: number, pageSize: number): Observable<ApiResponse<Empleado[]>> {
    return this.http.get<ApiResponse<Empleado[]>>(`/api/Empleados?PageNumber=${pageNumber}&PageSize=${pageSize}`);
  }

  getEmpleadoById(id: string): Observable<ApiResponse<Empleado>> {
    return this.http.get<ApiResponse<Empleado>>(`/api/Empleados/${id}`);
  }

  EliminarEmpleado(id: string): Observable<ApiResponse<number>>{
    return this.http.delete<ApiResponse<number>>(`/api/Empleados/${id}`);
  }

  CrearEmpleado(empleado: Empleado): Observable<ApiResponse<Empleado>> {
    return this.http.post<ApiResponse<Empleado>>(`/api/Empleados`, empleado);
  }

  ActualizarEmpleado(id: string, empleado: UpdateEmpleadoModel): Observable<ApiResponse<Empleado>> {
    return this.http.put<ApiResponse<Empleado>>(`/api/Empleados/${id}`, empleado);
  }

  SearchEmpleado(search: string): Observable<ApiResponse<Empleado[]>> {
    return this.http.get<ApiResponse<Empleado[]>>(`/api/Empleados/search/?search=${search}`);
  }

}
