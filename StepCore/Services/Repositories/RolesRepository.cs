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
    public class RolesRepository : GenericRepository<Roles>, IRolesRepository
    {
        private readonly ILogger<GenericRepository<Roles>> _logger;
        private readonly StepCoreContext _stepCoreContext;

        public RolesRepository(ILogger<GenericRepository<Roles>> logger, StepCoreContext stepCoreContext) : base(logger, stepCoreContext)
        {
            _logger = logger;
            _stepCoreContext = stepCoreContext;
        }

        public async Task<bool> IsInRole(string role, int userId)
        {
            var rol = await _stepCoreContext.
                Roles.
                FirstOrDefaultAsync(e => e.Name.ToLower() == role.ToLower());

            if (rol == null)
                throw new Exception("The role doesn't exists");

            return await _stepCoreContext
                .UserRoles
                .Where(e => e.UsersId == userId && e.RolesId == rol.Id).AnyAsync();
        }

        public async Task<TaskResult<Roles>> GetByNameAsync(string roleName)
        {
            return new TaskResult<Roles>
            {
                Data = await _stepCoreContext.Roles.FirstOrDefaultAsync(e => e.Name.ToLower() == roleName.ToLower())
            };

        }
    }
}
