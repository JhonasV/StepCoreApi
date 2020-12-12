using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StepCore.Entities;
using StepCore.Entities.Framework;
using StepCore.Framework;
using StepCore.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Z.EntityFramework.Plus;
using static StepCore.Framework.Constants;

namespace StepCore.Services.Repositories
{
    public class ApplicantsRepository : GenericRepository<Applicants>, IApplicantsRepository
    {
        private readonly ILogger<GenericRepository<Applicants>> _logger;
        private readonly StepCoreContext _stepCoreContext;
        private readonly IRolesRepository _rolesRepository;
        private readonly IGenericRepository<JobPositions> _jobPositionRepository;

        public ApplicantsRepository(ILogger<GenericRepository<Applicants>> logger, StepCoreContext stepCoreContext, IRolesRepository rolesRepository,
                                    IGenericRepository<JobPositions> jobPositionRepository) : base(logger, stepCoreContext)
        {
            _logger = logger;
            _stepCoreContext = stepCoreContext;
            _rolesRepository = rolesRepository;
            _jobPositionRepository = jobPositionRepository;
        }

        public async Task<TaskResult<bool>> AddCompentenciesRel(List<ApplicantsCompentencies> applicantsCompentencies)
        {
            var result = new TaskResult<bool>();
            try
            {
                await _stepCoreContext.ApplicantsCompentencies.AddRangeAsync(applicantsCompentencies);
                result.Data = await _stepCoreContext.SaveChangesAsync() > 0;
            }
            catch (System.Exception e)
            {
                result.AddErrorMessage("Error adding ApplicantsCompentencies: " + e.InnerException.Message);
            }

            return result;          
        }

        public async Task<TaskResult<bool>> AddLaborExperiencesRel(List<ApplicantsLaborExperiences> applicantsLaborExperiences)
        {
            var result = new TaskResult<bool>();
            try
            {
                await _stepCoreContext.ApplicantsLaborExperiences.AddRangeAsync(applicantsLaborExperiences);
                result.Data = await _stepCoreContext.SaveChangesAsync() > 0;
            }
            catch (System.Exception e)
            {
                result.AddErrorMessage("Error adding ApplicantsLaborExperiences: " + e.InnerException.Message);
            }

            return result;
        }

        public async Task<TaskResult<bool>> AddTrainingsRel(List<ApplicantsTrainings> applicantsTrainings)
        {
            var result = new TaskResult<bool>();
            try
            {
                await _stepCoreContext.ApplicantsTrainings.AddRangeAsync(applicantsTrainings);
                result.Data = await _stepCoreContext.SaveChangesAsync() > 0;
            }
            catch (System.Exception e)
            {
                result.AddErrorMessage("Error adding ApplicantsTrainings: " + e.InnerException.Message);
            }

            return result;
        }

        public async Task<TaskResult<List<Applicants>>> GetWithIncludes(Users currentUser)
        {
            _logger.LogInformation("Retrieve Applicants information with related entities objects");
            var result = new TaskResult<List<Applicants>>();
            result.Data = new List<Applicants>();
            var isAdmin = await _rolesRepository.IsInRole(RolesConstants.ADMIN, currentUser.Id);

            var applicants = _stepCoreContext
                .Applicants
                .Where(e => (e.UsersId == currentUser.Id || isAdmin) && e.Status == (int)Enums.Entities.Status.ENABLE)
                .ToList();

            applicants.ForEach((Applicants appl) =>
            {
                appl.LaborExperiences = this.GetApplicantLaborExperiences(appl.Id);
                appl.Compentencies = this.GetApplicantCompentencies(appl.Id);
                appl.Trainings = this.GetApplicantTrainings(appl.Id);
                appl.JobPositions = _jobPositionRepository.GetByIdAsync(appl.JobPositionsId).Result.Data;
            });

            result.Data = applicants;
            return result;
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

        public async Task<bool> RemoveApplicantTrainingsRel(int applicationTrainingsId)
        {
            return await _stepCoreContext
                .ApplicantsTrainings
                .DeleteFromQueryAsync(e => new ApplicantsTrainings { Id = applicationTrainingsId }) > 0;
        }

        public async Task<bool> RemoveApplicantCompentenciesRel(int applicantCompetenciesId)
        {
             return await _stepCoreContext
                .ApplicantsCompentencies
                .DeleteFromQueryAsync(e => new ApplicantsCompentencies { Id = applicantCompetenciesId }) > 0;
        }

        public async Task<bool> RemoveApplicantLaborExperiencesRel(int laborExperiencesId)
        {
            return await _stepCoreContext.ApplicantsLaborExperiences
            .DeleteFromQueryAsync(e => new ApplicantsLaborExperiences { Id = laborExperiencesId}) > 0;
        }

        public async Task<TaskResult<int>> CreateAsync(Applicants applicants)
        {
            var result = new TaskResult<int>();
            try
            {
                await _stepCoreContext.AddAsync(applicants);
                await _stepCoreContext.SaveChangesAsync();
                result.Data = applicants.Id;
            }
            catch (System.Exception e)
            {
                result.AddErrorMessage("Error adding applicant: "+ e.InnerException.Message);
            }

            return result;
        }
    }
}
