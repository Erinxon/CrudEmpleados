import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { EmpledoService } from 'src/app/services/empledo-service.service';

@Component({
  selector: 'app-agregar',
  templateUrl: './agregar.component.html',
  styleUrls: ['./agregar.component.css']
})
export class AgregarComponent implements OnInit {
  form = this.formBuilder.group({
    nombre: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(100)]],
    apellido: ['',  [Validators.required, Validators.minLength(3), Validators.maxLength(100)]],
    fechaNacimiento: ['', Validators.required],
    cargo: ['',  [Validators.required, Validators.minLength(3), Validators.maxLength(100)]],
    departamento: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(100)]],
    salario: [null, Validators.required],
    direccion: this.formBuilder.group({
      pais: ['',  [Validators.required, Validators.minLength(3), Validators.maxLength(100)]],
      provincia: ['',  [Validators.required, Validators.minLength(3), Validators.maxLength(100)]],
      sector: ['',  [Validators.required, Validators.minLength(3), Validators.maxLength(100)]],
      calle: ['', [Validators.required, Validators.minLength(1), Validators.maxLength(100)]],
      numeroCasa: ['',  [Validators.required, Validators.minLength(1), Validators.maxLength(100)]],
    })
  });

  constructor(private formBuilder: FormBuilder, private empleadoService: EmpledoService) { }

  ngOnInit(): void {

  }

  submit() {
    this.empleadoService.CrearEmpleado(this.form.value).subscribe(e => {
      if(e.succeeded) {
        this.reset();
      }
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
      pais: this.form.get('direccion.pais')!,
      provincia: this.form.get('direccion.provincia')!,
      sector: this.form.get('direccion.sector')!,
      calle: this.form.get('direccion.calle')!,
      numeroCasa: this.form.get('direccion.numeroCasa')!
   }
  }

  reset():void{
    this.form.reset();
  }

}
