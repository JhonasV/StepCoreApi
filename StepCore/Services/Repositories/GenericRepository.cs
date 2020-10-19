using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StepCore.Framework;
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

        public async Task<TaskResult<List<T>>> GetAsync()
        {
            var result = new TaskResult<List<T>>();
            result.Data = await _table.ToListAsync();
            return result;
        }

        public async Task<TaskResult<T>> GetByIdAsync(object id)
        {
            return new TaskResult<T> {Data = await _table.FindAsync(id) };
        }

        public async Task<bool> RemoveAsync(object id)
        {
            var existing = await this.GetByIdAsync(id);
            _table.Remove(existing.Data);
            return true;
        }

        public async Task<bool> SaveAsync()
        {
           return await _stepCoreContext.SaveChangesAsync() > 0;
        }

        public TaskResult<T> Update(T obj)
        {
            _table.Attach(obj);
            _stepCoreContext.Entry(obj).State = EntityState.Modified;
            return new TaskResult<T> { Data = obj};   
        }

       
    }
}
