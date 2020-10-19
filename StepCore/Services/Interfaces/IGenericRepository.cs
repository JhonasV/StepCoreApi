using StepCore.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StepCore.Services.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> CreateAsync(T obj);
        Task<TaskResult<List<T>>> GetAsync();
        Task<TaskResult<T>> GetByIdAsync(object id);
        Task<bool> RemoveAsync(object id);
        TaskResult<T> Update(T obj);
        Task<bool> SaveAsync();
    }
}
