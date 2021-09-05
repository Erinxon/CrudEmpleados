using System;
using System.Text.Json.Serialization;
using ApiEmpleado.DTOs.DireccionDtos;
using ApiEmpleado.Entities;

namespace ApiEmpleado.DTOs.EmpleadoDtos
{
    public class EmpleadoDto
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Cargo { get; set; }
        public string Departamento { get; set; }
        public decimal Salario { get; set; }
        [JsonIgnore]
        public Guid DireccionId { get; set; }
        public bool IsActive { get; set; }
        public DireccionDto Direccion { get; set; }
    }
}