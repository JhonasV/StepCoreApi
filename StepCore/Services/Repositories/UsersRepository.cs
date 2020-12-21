using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StepCore.Entities;
using StepCore.Framework;
using StepCore.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Roles = StepCore.Entities.Roles;

namespace StepCore.Services.Repositories
{
    public class UsersRepository : GenericRepository<Users>, IUsersRepository
    {
        private readonly ILogger<GenericRepository<Users>> _logger;
        private readonly StepCoreContext _stepCoreContext;

        public UsersRepository(ILogger<GenericRepository<Users>> logger, StepCoreContext stepCoreContext) : base(logger, stepCoreContext)
        {
           _logger = logger;
           _stepCoreContext = stepCoreContext;
        }

        public async Task<bool> AddUserRoleAsync(int roleId, int userId)
        {
        
            await _stepCoreContext.UserRoles.AddAsync(new UserRoles { RolesId = roleId, UsersId = userId });
            return await _stepCoreContext.SaveChangesAsync() > 0;
        }



        public async Task<Users> GetByUserNameAsync(string userName)
        {

            var user = await _stepCoreContext.Users.FirstOrDefaultAsync(e => e.UserName == userName);
            if(user != null)
                user.Roles = await this.GetUserRolesAsync(user.Id);
            return user;
        }

 

        public async Task<List<Roles>> GetUserRolesAsync(int userId)
        {
            return await _stepCoreContext.UserRoles.Where(e => e.UsersId == userId)
                 .Include(e => e.Role)
                 .Select(e => e.Role).ToListAsync();
        }

    }
}
