using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ApiEmpleado.Data;
using Microsoft.EntityFrameworkCore;

namespace ApiEmpleado.Repository
{
    public class GenericRepositoryAsync<T>: IGenericRepositoryAsync<T> where T: class
    {
        private readonly ApplicationDbContext _context;
        protected readonly DbSet<T> _dbSet;
        public GenericRepositoryAsync(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        
        public async Task<T> GetById(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.Where(expression).ToListAsync();
        }

        public async Task<T> Add(T entity)
        {
            await _dbSet.AddAsync(entity);
            return entity;
        }

        public async Task<IEnumerable<T>> AddRange(IEnumerable<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
            return entities;
        }

        public async Task Remove(T entity)
        {
             _dbSet.Remove(entity);
        }

        public async Task RemoveRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public async Task Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

    }
}