using System;

namespace ApiEmpleado.Entities
{
    public class Direccion : BaseEntity
    {
        public string Pais { get; set; }
        public string Provincia { get; set; }
        public string Sector { get; set; }
        public string Calle { get; set; }
        public string NumeroCasa { get; set; }
    }
}