using StepCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StepCore.Services.Interfaces
{
    public interface ISkillsRepository
    {
        Task<Skills> Create(Skills skills);
        Task<List<Skills>> Get();
        Task<Skills> Get(int id);
        Task<bool> Remove(int id);
        //Task<bool> Update(int id, Skills skills);
    }
}
