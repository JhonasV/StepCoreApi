using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StepCore.Services.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> CreateAsync(T obj);
        Task<List<T>> GetAsync();
        Task<T> GetByIdAsync(object id);
        Task<bool> RemoveAsync(object id);
        Task<bool> UpdateAsync(T obj);
        Task<bool> SaveAsync();
    }
}
