using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiEmpleado.Entities.EntityConfig
{
    public class DireccionConfig : IEntityTypeConfiguration<Direccion>
    {
        public void Configure(EntityTypeBuilder<Direccion> builder)
        {
            builder.HasIndex(e => e.Id);
            builder.Property(p => p.Pais)
                .HasColumnType("varchar(100)")
                .IsRequired();
            builder.Property(p => p.Provincia)
                .HasColumnType("varchar(100)")
                .IsRequired();
            builder.Property(p => p.Sector)
                .HasColumnType("varchar(100)")
                .IsRequired();
            builder.Property(p => p.Calle)
                .HasColumnType("varchar(100)")
                .IsRequired();
            builder.Property(p => p.NumeroCasa)
                .HasColumnType("varchar(100)")
                .IsRequired();

        }
    }
}