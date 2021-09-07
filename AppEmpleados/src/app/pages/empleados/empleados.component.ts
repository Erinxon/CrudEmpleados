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
  pageNumber: number = 1;
  pageSize: number = 10;
  totalPaginas: number =1;
  listaPageSizes: number[] = [5, 10, 15, 20];

  constructor(private empleadoService: EmpledoService, private router: Router) { }

  ngOnInit(): void {
    this.getEmpleados();
  }

  getEmpleados(): void {
    this.empleadoService.getEmpleados(this.pageNumber, this.pageSize).subscribe(e => {
      this.totalPaginas = Math.ceil(e.totalRegistros / this.pageSize);
      this.empleados = e.data;
    })
  }

  getEstatusString(estatus: boolean): string {
    return estatus === true ? 'Activo' : 'Inactivo';
  }

  EliminarEmpleado(id: string): void {
    this.empleadoService.EliminarEmpleado(id).subscribe(e => {
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
    }else{
      this.getEmpleados();
    }
  }
  
  getPageAnterior(): void {
    this.pageNumber--;
    this.getEmpleados();
  }

  getPageSiguiente(): void {
    this.pageNumber++;
    this.getEmpleados();
  }

}
