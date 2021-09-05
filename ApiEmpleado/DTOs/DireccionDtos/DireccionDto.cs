using System;

namespace ApiEmpleado.DTOs.DireccionDtos
{
    public class DireccionDto
    {
        public Guid Id { get; set; }
        public string Pais { get; set; }
        public string Provincia { get; set; }
        public string Sector { get; set; }
        public string Calle { get; set; }
        public string NumeroCasa { get; set; }
    }
}