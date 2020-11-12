using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StepCore.Entities;
using StepCore.Framework;
using StepCore.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StepCore.Services.Repositories
{
    public class LaborExperiencesRepository : GenericRepository<LaborExperiences>, ILaborExperiencesRepository
    {
        private readonly StepCoreContext _stepCoreContext;

        public LaborExperiencesRepository(ILogger<GenericRepository<LaborExperiences>> logger, StepCoreContext stepCoreContext) : base(logger, stepCoreContext)
        {
            _stepCoreContext = stepCoreContext;
        }

        public async Task<TaskResult<List<LaborExperiences>>> GetListByUserId(int userId)
        {
            var result = new TaskResult<List<LaborExperiences>>();
             result.Data = await _stepCoreContext
                .LaborExperiences
                .Where(l => l.UserId == userId)
                .Include(e => e.Users)
                .ToListAsync();

            return result;
        }
    }
}
