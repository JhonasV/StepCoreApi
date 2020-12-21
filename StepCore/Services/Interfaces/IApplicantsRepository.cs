using StepCore.Entities;
using StepCore.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StepCore.Services.Interfaces
{
    public interface IApplicantsRepository : IGenericRepository<Applicants>
    {
        new Task<TaskResult<int>> CreateAsync(Applicants applicants);
        Task<TaskResult<List<Applicants>>> GetWithIncludesAsync(Users currentUser);
        Task<TaskResult<bool>> AddTrainingsRelAsync(List<ApplicantsTrainings> applicantsTrainings);
        Task<TaskResult<bool>> AddCompentenciesRelAsync(List<ApplicantsCompentencies> applicantsCompentencies);
        Task<TaskResult<bool>> AddLaborExperiencesRelAsync(List<ApplicantsLaborExperiences> applicantsLaborExperiences);
        List<Trainings> GetApplicantTrainings(int applicantId);
        List<Compentencies> GetApplicantCompentencies(int applicantId);
        List<LaborExperiences> GetApplicantLaborExperiences(int applicantId);
        Task<bool> RemoveApplicantTrainingsRelAsync(int applicationTrainingsId);
        Task<bool> RemoveApplicantCompentenciesRelAsync(int applicationTrainingsId);
        Task<bool> RemoveApplicantLaborExperiencesRelAsync(int applicationTrainingsId);
    }
}
