import { Direccion } from "./Direccion";

export interface Empleado {
    id: string;
    nombre: string;
    apellido: string;
    fechaNacimiento: Date;
    cargo: string;
    departamento: string;
    salario: number;
    isActive: boolean;
    direccion: Direccion;
}
