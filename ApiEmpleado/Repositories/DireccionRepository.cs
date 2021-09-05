using ApiEmpleado.Data;
using ApiEmpleado.Entities;
using ApiEmpleado.Repository;

namespace ApiEmpleado.Repositories
{
    public class DireccionRepository : GenericRepositoryAsync<Direccion>, IDireccionRepository
    {
        public DireccionRepository(ApplicationDbContext context): base(context)
        {
            
        }
        
    }
}