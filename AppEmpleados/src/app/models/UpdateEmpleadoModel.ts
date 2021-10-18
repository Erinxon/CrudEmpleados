import { Direccion } from "./Direccion";

export interface UpdateEmpleadoModel {
    nombre: string;
    apellido: string;
    fechaNacimiento: Date;
    cargo: string;
    departamento: string;
    salario: number;
    cedula: string;
    isActive: boolean;
    direccion: Direccion;
}
