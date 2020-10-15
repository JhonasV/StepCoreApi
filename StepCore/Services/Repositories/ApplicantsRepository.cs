﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StepCore.Entities;
using StepCore.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StepCore.Services.Repositories
{
    public class ApplicantsRepository : GenericRepository<Applicants>, IApplicantsRepository
    {
        private readonly ILogger<GenericRepository<Applicants>> _logger;
        private readonly StepCoreContext _stepCoreContext;

        public ApplicantsRepository(ILogger<GenericRepository<Applicants>> logger, StepCoreContext stepCoreContext) : base(logger, stepCoreContext)
        {
            _logger = logger;
            _stepCoreContext = stepCoreContext;
        }

        public async Task<bool> AddCompentenciesRel(ApplicantsCompentencies applicantsCompentencies)
        {
            await _stepCoreContext.ApplicantsCompentencies.AddAsync(applicantsCompentencies);
            return await _stepCoreContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> AddLaborExperiencesRel(ApplicantsLaborExperiences applicantsLaborExperiences)
        {
            await _stepCoreContext.ApplicantsLaborExperiences.AddAsync(applicantsLaborExperiences);
            return await _stepCoreContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> AddTrainingsRel(ApplicantsTrainings applicantsTrainings)
        {
            await _stepCoreContext.ApplicantsTrainings.AddAsync(applicantsTrainings);
            return await _stepCoreContext.SaveChangesAsync() > 0;
        }

        public List<Applicants> GetWithIncludes()
        {
            _logger.LogInformation("Retrieve Applicants information with related entities objects");
            var applicants = _stepCoreContext
                .Applicants
                .ToList();

            applicants.ForEach((Applicants appl) =>
            {
                appl.LaborExperiences = this.GetApplicantLaborExperiences(appl.Id);
                appl.Compentencies = this.GetApplicantCompentencies(appl.Id);
                appl.Trainings = this.GetApplicantTrainings(appl.Id);
            });

            return applicants;
        }

        public List<Compentencies> GetApplicantCompentencies(int applicantId)
        {
          return  _stepCoreContext
               .ApplicantsCompentencies
               .Where(e => e.ApplicantsId == applicantId)
               .Include(e => e.Compentencie)
               .Select(e => e.Compentencie)
               .ToList();
        }

        public List<LaborExperiences> GetApplicantLaborExperiences(int applicantId)
        {
            return  _stepCoreContext
                .ApplicantsLaborExperiences
                .Where(e => e.ApplicantsId == applicantId)
                .Include(e => e.LaborExperience)
                .Select(e => e.LaborExperience)
                .ToList();
        }

       public List<Trainings> GetApplicantTrainings(int applicantId)
        {
            
           return  _stepCoreContext
                .ApplicantsTrainings
                .Where(e => e.ApplicantsId == applicantId)
                .Include(e => e.Training)
                .Select(e => e.Training)
                .ToList();
        }
    }
}
