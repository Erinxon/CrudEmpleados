import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Empleado } from 'src/app/models/Empleado';
import { EmpledoService } from 'src/app/services/empledo-service.service';

@Component({
  selector: 'app-detalle',
  templateUrl: './detalle.component.html',
  styleUrls: ['./detalle.component.css']
})
export class DetalleComponent implements OnInit {
  empleado!: Empleado;

  constructor(private empleadoService: EmpledoService, private activatedRoute: ActivatedRoute) { }

  ngOnInit(): void {
    this.getEmpleado();
  }

  getEmpleado(): void {
    const id = this.getIdParam();
    this.empleadoService.getEmpleadoById(id).subscribe(e => {
      this.empleado = e.data;
    });
  }

  
  getIdParam(): string {
    return this.activatedRoute.snapshot.paramMap.get('id')!;
  }

  getLetrasIniciales(nombre: string): string {
    return nombre.substr(-nombre.length,1);
  }

  getEstadoStringEmpleado(estado: boolean): string {
    return estado ? 'Activo' : 'Inactivo';
  }

}
