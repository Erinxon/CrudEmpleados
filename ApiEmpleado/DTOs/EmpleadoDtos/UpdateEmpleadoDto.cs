using System;
using ApiEmpleado.DTOs.DireccionDtos;

namespace ApiEmpleado.DTOs.EmpleadoDtos
{
    public class UpdateEmpleadoDto
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Cargo { get; set; }
        public string Departamento { get; set; }
        public decimal Salario { get; set; }
        public bool IsActive { get; set; }
        public UpdateDireccionDto Direccion { get; set; }
    }
}