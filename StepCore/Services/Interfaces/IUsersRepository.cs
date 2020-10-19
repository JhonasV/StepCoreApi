using StepCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StepCore.Services.Interfaces
{
    public interface IUsersRepository : IGenericRepository<Users>
    {
        Task<Users> GetByUserNameAsync(string userName);
        Task<bool> AddUserRole(int roleId, int userId);

        Task<List<Roles>> GetUserRolesAsync(int userId);
    }
}
