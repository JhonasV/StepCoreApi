using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StepCore.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StepCore.Services.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ILogger<GenericRepository<T>> _logger;
        private readonly StepCoreContext _stepCoreContext;
        private readonly DbSet<T> _table;
        public GenericRepository(ILogger<GenericRepository<T>> logger, StepCoreContext stepCoreContext)
        {
           _logger = logger;
           _stepCoreContext = stepCoreContext;
           _table = _stepCoreContext.Set<T>();
        }
        public async Task<T> CreateAsync(T obj)
        {
            await _table.AddAsync(obj);
            return obj;
        }

        public async Task<List<T>> GetAsync()
        {
            return await _table.ToListAsync();
        }

        public async Task<T> GetByIdAsync(object id)
        {
            return await _table.FindAsync(id);
        }

        public async Task<bool> RemoveAsync(object id)
        {
            T existing = await this.GetByIdAsync(id);
            _table.Remove(existing);
            return true;
        }

        public async Task<bool> SaveAsync()
        {
           return await _stepCoreContext.SaveChangesAsync() > 0;
        }

        public T Update(T obj)
        {
            _table.Attach(obj);
            _stepCoreContext.Entry(obj).State = EntityState.Modified;
            return obj;   
        }
    }
}
