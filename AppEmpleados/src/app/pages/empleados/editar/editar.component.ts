import { formatDate } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Empleado } from 'src/app/models/Empleado';
import { EmpledoService } from 'src/app/services/empledo-service.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-editar',
  templateUrl: './editar.component.html',
  styleUrls: ['./editar.component.css']
})
export class EditarComponent implements OnInit {
  empleado!: Empleado;
  form!: FormGroup;
  
  constructor(private activatedRoute: ActivatedRoute, private formBuilder: FormBuilder,
    private router: Router, private empleadoService: EmpledoService,
    private toastr: ToastrService) { 
      
    }

  ngOnInit(): void {
    this.getEmpleadoById();
  }

  getIdParam(): string {
    return this.activatedRoute.snapshot.paramMap.get('id')!;
  }

  getEmpleadoById(){
    const id = this.getIdParam();
    this.empleadoService.getEmpleadoById(id).subscribe(e => {
      this.empleado = e.data;
      this.setValueForm();
    })
  }

  setValueForm(): void {
    this.form = this.formBuilder.group({
      nombre: [this.empleado.nombre, [Validators.required, Validators.minLength(3), Validators.maxLength(100)]],
      apellido: [this.empleado.apellido,  [Validators.required, Validators.minLength(3), Validators.maxLength(100)]],
      fechaNacimiento: [formatDate(this.empleado.fechaNacimiento, 'yyyy-MM-dd', 'en'), Validators.required],
      cargo: [this.empleado.cargo,  [Validators.required, Validators.minLength(3), Validators.maxLength(100)]],
      departamento: [this.empleado.departamento, [Validators.required, Validators.minLength(3), Validators.maxLength(100)]],
      salario: [this.empleado.salario, Validators.required],
      isActive: [this.empleado.isActive, Validators.required],
      direccion: this.formBuilder.group({
        id: [this.empleado.direccion.id, Validators.required],
        pais: [this.empleado.direccion.pais,  [Validators.required, Validators.minLength(3), Validators.maxLength(100)]],
        provincia: [this.empleado.direccion.provincia,  [Validators.required, Validators.minLength(3), Validators.maxLength(100)]],
        sector: [this.empleado.direccion.sector,  [Validators.required, Validators.minLength(3), Validators.maxLength(100)]],
        calle: [this.empleado.direccion.calle, [Validators.required, Validators.minLength(1), Validators.maxLength(100)]],
        numeroCasa: [this.empleado.direccion.numeroCasa,  [Validators.required, Validators.minLength(1), Validators.maxLength(100)]],
      })
    });
  }

  get statusCampos() {
    return {
      nombre: this.form.get('nombre')!,
      apellido: this.form.get('apellido')!,
      fechaNacimiento: this.form.get('fechaNacimiento')!,
      cargo: this.form.get('cargo')!,
      departamento: this.form.get('departamento')!,
      salario: this.form.get('salario')!,
      isActive: this.form.get('isActive')!,
      pais: this.form.get('direccion.pais')!,
      provincia: this.form.get('direccion.provincia')!,
      sector: this.form.get('direccion.sector')!,
      calle: this.form.get('direccion.calle')!,
      numeroCasa: this.form.get('direccion.numeroCasa')!
   }
  }

  submit(): void {
    this.empleadoService.ActualizarEmpleado(this.empleado.id, this.form.value).subscribe(e => {
      if(e.succeeded){
        this.toastr.success('Empleado actualizado correctamente', 'Actualizado');
        this.ToHome();
      }else{
        this.toastr.error('Error al actualizar empleado', 'Error');
      }
    })
  }

  ToHome(): void {
    this.router.navigate(['/']);
  }

}
