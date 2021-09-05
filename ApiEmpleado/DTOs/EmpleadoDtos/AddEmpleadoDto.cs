using System;
using System.Text.Json.Serialization;
using ApiEmpleado.DTOs.DireccionDtos;

namespace ApiEmpleado.DTOs.EmpleadoDtos
{
    public class AddEmpleadoDto
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Cargo { get; set; }
        public string Departamento { get; set; }
        public decimal Salario { get; set; }
        [JsonIgnore]
        public Guid DireccionId { get; set; }
        public AddDireccionDto Direccion { get; set; }
    }
}