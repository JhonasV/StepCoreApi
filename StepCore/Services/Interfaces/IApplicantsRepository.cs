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
        Task<TaskResult<int>> CreateAsync(Applicants applicants);
        Task<TaskResult<List<Applicants>>> GetWithIncludes(Users currentUser);
        Task<TaskResult<bool>> AddTrainingsRel(List<ApplicantsTrainings> applicantsTrainings);
        Task<TaskResult<bool>> AddCompentenciesRel(List<ApplicantsCompentencies> applicantsCompentencies);
        Task<TaskResult<bool>> AddLaborExperiencesRel(List<ApplicantsLaborExperiences> applicantsLaborExperiences);
        List<Trainings> GetApplicantTrainings(int applicantId);
        List<Compentencies> GetApplicantCompentencies(int applicantId);
        List<LaborExperiences> GetApplicantLaborExperiences(int applicantId);
        Task<bool> RemoveApplicantTrainingsRel(int applicationTrainingsId);
        Task<bool> RemoveApplicantCompentenciesRel(int applicationTrainingsId);
        Task<bool> RemoveApplicantLaborExperiencesRel(int applicationTrainingsId);
    }
}
