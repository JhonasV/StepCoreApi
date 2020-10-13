using StepCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StepCore.Services.Interfaces
{
    public interface ICompentenciesRepository
    {
        Task<Compentencies> Create(Compentencies compentencies);
        Task<List<Compentencies>> Get();
        Task<Compentencies> Get(int id);
        Task<bool> Remove(int id);
        Task<bool> Update(int id, Compentencies compentencies);
    }
}
