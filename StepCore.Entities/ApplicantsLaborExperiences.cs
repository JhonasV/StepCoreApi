using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StepCore.Entities
{
    public class ApplicantsLaborExperiences : Entitie
    {
        [Required]
        public int ApplicantsId { get; set; }
        [Required]
        public int LaborExperiencesId { get; set; }
        public bool IsPrincipal { get; set; }
        public virtual Applicants Applicant { get; set; }
        public virtual LaborExperiences LaborExperience { get; set; }
    }
}
