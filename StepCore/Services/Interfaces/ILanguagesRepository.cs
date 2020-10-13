using StepCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StepCore.Services.Interfaces
{
    public interface ILanguagesRepository
    {
        Task<Languages> Create(Languages Language);
        Task<List<Languages>> Get();
        Task<Languages> Get(int id);
        Task<bool> Remove(int id);
        Task<bool> Update(int id, Languages Languages);
    }
}
