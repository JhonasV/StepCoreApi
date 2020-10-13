using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StepCore.Entities;
using StepCore.Entities.Common;
using StepCore.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StepCore.Services.Repositories
{
    public class CompentenciesRepository : ICompentenciesRepository
    {
        private readonly StepCoreContext _context;
        private readonly ILogger<CompentenciesRepository> _logger;

        public CompentenciesRepository(StepCoreContext context, ILogger<CompentenciesRepository> logger)
        {
            _context =context;
            _logger = logger;
        }

        public async Task<Compentencies> Create(Compentencies skills)
        {
            await _context.Compentencies.AddAsync(skills);
            await _context.SaveChangesAsync();
            _logger.LogError($"Object Skills created with id {skills.Id}");
            return skills;
        }

        public async Task<List<Compentencies>> Get()
        {
            return await _context.Compentencies.ToListAsync();
        }

        public async Task<Compentencies> Get(int id)
        {
            return await _context.Compentencies.FirstOrDefaultAsync(e => e.Id == id);
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
                _context.Compentencies.Remove(skill);
                bool success = await _context.SaveChangesAsync() > 0;
                if (success)
                {
                    _logger.LogError($"Object of type Skills with id {id} was removed");
                    return success;
                }
            }

            throw new Exception("Error saving changes");
        }

        public async Task<bool> Update(int id, Compentencies compentencies)
        {
            var originalCompentencie = await _context.Compentencies.FindAsync(id);

            originalCompentencie.Description = compentencies.Description;
            originalCompentencie.Status = compentencies.Status == (int)Enums.Entities.Status.ENABLE ? (int)Enums.Entities.Status.ENABLE : (int)Enums.Entities.Status.DISABLE;
            originalCompentencie.UpdatedAt = DateTime.Now;

            var isUpdated = await _context.SaveChangesAsync() > 0;

            if (isUpdated)
            {
                _logger.LogInformation($"The compentency with Id: {id} has been updated");
            }
            else
            {
                _logger.LogError($"Error updating the compentency with Id: {id} ");
            }
            return isUpdated;
        }

   
    }
}
