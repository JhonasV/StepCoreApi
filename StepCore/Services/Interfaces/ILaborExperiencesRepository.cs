﻿using StepCore.Entities;
using StepCore.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StepCore.Services.Interfaces
{
    public interface ILaborExperiencesRepository : IGenericRepository<LaborExperiences>
    {
        Task<TaskResult<List<LaborExperiences>>> GetAsync(Users currentUser);
        Task<TaskResult<List<LaborExperiences>>> GetListByUserId(int userId);
    }
}
