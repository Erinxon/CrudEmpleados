using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ApiEmpleado.Data;
using ApiEmpleado.Entities;
using ApiEmpleado.Repository;

namespace ApiEmpleado.Repositories
{
    public class EmpleadoRepository : GenericRepositoryAsync<Empleado>, IEmpleadoRepository
    {
        
        public EmpleadoRepository(ApplicationDbContext context): base(context)
        {
            
        }
        
    }
}