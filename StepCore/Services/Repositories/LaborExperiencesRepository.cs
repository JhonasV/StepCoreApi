using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StepCore.Entities;
using StepCore.Framework;
using StepCore.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static StepCore.Data.Framework.Constants;

namespace StepCore.Services.Repositories
{
    public class LaborExperiencesRepository : GenericRepository<LaborExperiences>, ILaborExperiencesRepository
    {
        private readonly StepCoreContext _stepCoreContext;
        private readonly IRolesRepository _rolesRepository;

        public LaborExperiencesRepository(ILogger<GenericRepository<LaborExperiences>> logger, StepCoreContext stepCoreContext, IRolesRepository rolesRepository) : base(logger, stepCoreContext)
        {
            _stepCoreContext = stepCoreContext;
            _rolesRepository = rolesRepository;
        }

        public async Task<TaskResult<List<LaborExperiences>>> GetAsync(Users currentUser)
        {
            var result = new TaskResult<List<LaborExperiences>>();
            var isAdmin = await _rolesRepository.IsInRole(RolesConstants.ADMIN, currentUser.Id);
            result.Data = await _stepCoreContext
                .LaborExperiences
                .Where(e => e.UserId == currentUser.Id || isAdmin)
                .ToListAsync();

            return result;
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
