using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiEmpleado.Entities.EntityConfig
{
    public class EmpleadoConfig : IEntityTypeConfiguration<Empleado>
    {
        public void Configure(EntityTypeBuilder<Empleado> builder)
        {
            builder.HasIndex(e => e.Id);
            builder.Property(p => p.Nombre)
                .HasColumnType("varchar(100)")
                .IsRequired();
            builder.Property(p => p.Apellido)
                .HasColumnType("varchar(100)")
                .IsRequired();
            builder.Property(p => p.FechaNacimiento)
                .HasColumnType("datetime")
                .IsRequired();
            builder.Property(p => p.Cargo)
                .HasColumnType("varchar(100)")
                .IsRequired();
            builder.Property(p => p.Departamento)
                .HasColumnType("varchar(100)")
                .IsRequired();
            builder.Property(p => p.Salario)
                .HasColumnType("decimal(15,2)")
                .IsRequired();
            builder.Property(p => p.Cedula)
                .HasColumnType("varchar(11)")
                .IsRequired();
            builder.Property(p => p.DireccionId)
                .IsRequired();
            builder.Property(p => p.FechaCreacion)
                .HasColumnType("datetime")
                .IsRequired();
            builder.Property(p => p.IsActive)
                .HasColumnType("bit");
        }
    }
}