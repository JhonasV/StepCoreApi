using StepCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StepCore.Framework.Models.Applicants
{
    public class ApplicantsCreateModel
    {
       public Entities.Applicants Applicants { get; set; }
       public List<ApplicantsTrainings> ApplicantsTrainings { get; set; }

       public List<ApplicantsCompentencies> ApplicantsCompentencies { get; set; }
       public List<ApplicantsLaborExperiences> ApplicantsLaborExperiences { get; set; }

       public ApplicantsCreateModel()
        {
            this.Applicants = new Entities.Applicants();
            this.ApplicantsTrainings = new List<ApplicantsTrainings>();
            this.ApplicantsCompentencies = new List<ApplicantsCompentencies>();
            this.ApplicantsLaborExperiences = new List<ApplicantsLaborExperiences>();

        }
    }
}
