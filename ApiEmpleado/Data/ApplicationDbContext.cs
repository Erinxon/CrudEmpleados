using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ApiEmpleado.Entities;
using ApiEmpleado.Entities.EntityConfig;
using Microsoft.EntityFrameworkCore;

namespace ApiEmpleado.Data
{
    
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
           
        }
        
        public  DbSet<Direccion> Direcciones { get; set; }
        public  DbSet<Empleado> Empleados { get; set; }
        
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                entry.Entity.Id = entry.State switch
                {
                    EntityState.Added => Guid.NewGuid(),
                    _ => entry.Entity.Id
                };
            }
            return base.SaveChangesAsync(cancellationToken);
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DireccionConfig());
            modelBuilder.ApplyConfiguration(new EmpleadoConfig());
           
            base.OnModelCreating(modelBuilder);
        }
        

    }
}