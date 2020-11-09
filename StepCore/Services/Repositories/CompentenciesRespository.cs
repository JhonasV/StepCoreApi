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
    public class CompentenciesRespository : GenericRepository<Compentencies>, ICompentenciesRepository
    {
        private readonly StepCoreContext _stepCoreContext;

        public CompentenciesRespository(ILogger<GenericRepository<Compentencies>> logger, StepCoreContext stepCoreContext) : base(logger, stepCoreContext)
        {
            _stepCoreContext = stepCoreContext;
        }

    }
}
