using System;

namespace ApiEmpleado.Entities
{
    public class Empleado : BaseEntity
    {
        public Empleado()
        {
            this.IsActive = true;
        }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Cargo { get; set; }
        public string Departamento { get; set; }
        public decimal Salario { get; set; }
        public Guid DireccionId { get; set; }
        public bool IsActive { get; set; }
        public Direccion Direccion { get; set; }
        
    }
}