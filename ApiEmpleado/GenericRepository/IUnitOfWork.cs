using System;
using System.Threading.Tasks;
using ApiEmpleado.Repositories;

namespace ApiEmpleado.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IDireccionRepository DireccionRepository { get; }
        IEmpleadoRepository EmpleadoRepository { get; }
        Task<int> SavechangesAsync();
    }
}