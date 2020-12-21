using StepCore.Entities;
using StepCore.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Roles = StepCore.Entities.Roles;

namespace StepCore.Services.Interfaces
{
    public interface IUsersRepository : IGenericRepository<Users>
    {
        Task<Users> GetByUserNameAsync(string userName);
        Task<bool> AddUserRoleAsync(int roleId, int userId);
        Task<List<Roles>> GetUserRolesAsync(int userId);
    }

}
