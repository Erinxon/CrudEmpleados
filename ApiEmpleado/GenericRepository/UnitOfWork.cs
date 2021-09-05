using System;
using System.Threading.Tasks;
using ApiEmpleado.Data;
using ApiEmpleado.Repositories;

namespace ApiEmpleado.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private readonly IDireccionRepository _direccionRepository;
        private readonly IEmpleadoRepository _empleadoRepository;
        
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public IDireccionRepository DireccionRepository => _direccionRepository ?? new DireccionRepository(_context);
        public IEmpleadoRepository EmpleadoRepository => _empleadoRepository ?? new EmpleadoRepository(_context);

        public async Task<int> SavechangesAsync()
        {
            return await this._context.SaveChangesAsync();
        }
  
        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }
    }
}