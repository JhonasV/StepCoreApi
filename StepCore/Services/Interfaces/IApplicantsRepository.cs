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
        TaskResult<List<Applicants>> GetWithIncludes();
        Task<bool> AddTrainingsRel(ApplicantsTrainings applicantsTrainings);
        Task<bool> AddCompentenciesRel(ApplicantsCompentencies applicantsCompentencies);
        Task<bool> AddLaborExperiencesRel(ApplicantsLaborExperiences applicantsLaborExperiences);
        List<Trainings> GetApplicantTrainings(int applicantId);
        List<Compentencies> GetApplicantCompentencies(int applicantId);
        List<LaborExperiences> GetApplicantLaborExperiences(int applicantId);
        Task<bool> RemoveApplicantTrainingsRel(int applicationTrainingsId);
        Task<bool> RemoveApplicantCompentenciesRel(int applicationTrainingsId);
        Task<bool> RemoveApplicantLaborExperiencesRel(int applicationTrainingsId);
    }
}
