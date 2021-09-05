import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Empleado } from 'src/app/models/Empleado';
import { EmpledoService } from 'src/app/services/empledo-service.service';

@Component({
  selector: 'app-empleados',
  templateUrl: './empleados.component.html',
  styleUrls: ['./empleados.component.css']
})
export class EmpleadosComponent implements OnInit {
  empleados!: Empleado[];
  searchText: string = '';

  constructor(private empleadoService: EmpledoService, private router: Router) { }

  ngOnInit(): void {
    this.getEmpleados();
  }

  getEmpleados(): void {
    this.empleadoService.getEmpleados().subscribe(e => {
      this.empleados = e.data;
    })
  }

  getEstatusString(estatus: boolean): string {
    return estatus === true ? 'Activo' : 'Inactivo';
  }

  EliminarEmpleado(id: string): void {
    this.empleadoService.EliminarEmpleado(id).subscribe(e => {
      console.log(e);
      this.getEmpleados();
    });

  }

  ToPageAgregar(): void {
    this.router.navigate(['/agregar']);
  }

  ToPageEditar(id: string): void {
    this.router.navigate([`/editar/${id}`])
  }

  ToPageDetalle(id: string): void {
    this.router.navigate([`/detalle/${id}`])
  }

  SearchEmpleado(): void {
    if(this.searchText) {
      this.empleadoService.SearchEmpleado(this.searchText).subscribe(e => {
        this.empleados = e.data;
      })
    }   
  }
  

}
