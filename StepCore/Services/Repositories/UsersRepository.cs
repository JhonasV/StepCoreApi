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
    public class UsersRepository : GenericRepository<Users>, IUsersRepository
    {
        private readonly ILogger<GenericRepository<Users>> _logger;
        private readonly StepCoreContext _stepCoreContext;

        public UsersRepository(ILogger<GenericRepository<Users>> logger, StepCoreContext stepCoreContext) : base(logger, stepCoreContext)
        {
           _logger = logger;
           _stepCoreContext = stepCoreContext;
        }

        public async Task<Users> GetByUserNameAsync(string userName)
        {
            return await _stepCoreContext.Users.FirstOrDefaultAsync(e => e.UserName == userName);
        }
    }
}
