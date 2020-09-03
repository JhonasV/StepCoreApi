using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StepCore.Entities;
using StepCore.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StepCore.Services.Repositories
{
    public class SkillsRepository : ISkillsRepository
    {
        private readonly StepCoreContext _context;
        private readonly ILogger<SkillsRepository> _logger;

        public SkillsRepository(StepCoreContext context, ILogger<SkillsRepository> logger)
        {
            _context =context;
            _logger = logger;
        }

        public async Task<Skills> Create(Skills skills)
        {
            await _context.Skills.AddAsync(skills);
            await _context.SaveChangesAsync();
            _logger.LogError($"Object Skills created with id {skills.Id}");
            return skills;
        }

        public async Task<List<Skills>> Get()
        {
            return await _context.Skills.ToListAsync();
        }

        public async Task<Skills> Get(int id)
        {
            return await _context.Skills.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<bool> Remove(int id)
        {
            var skill = await this.Get(id);
            if(skill == null)
            {
                _logger.LogError("Could not find activity");
                throw new Exception("Could not find activity");

            }
            else
            {
                _context.Skills.Remove(skill);
                bool success = await _context.SaveChangesAsync() > 0;
                if (success)
                {
                    _logger.LogError($"Object of type Skills with id {id} was removed");
                    return success;
                }
            }

            throw new Exception("Error saving changes");
        }

        //public async Task<bool> Update(int id, Skills skills)
        //{
        //    throw NotImplementedException;
        //}
    }
}
