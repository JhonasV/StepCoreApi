﻿using StepCore.Entities;
using StepCore.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StepCore.Services.Interfaces
{
    public interface IRolesRepository : IGenericRepository<Roles>
    {
        Task<bool> IsInRole(string role, int userId);
        Task<TaskResult<Roles>> GetByNameAsync(String roleName);
    }
}
