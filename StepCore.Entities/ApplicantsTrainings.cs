using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StepCore.Entities
{
    public class ApplicantsTrainings : Entitie
    {
        [Required]
        public int ApplicantsId { get; set; }
        [Required]
        public int TrainingsId { get; set; }

        public virtual Applicants Applicant { get; set; }
        public virtual Trainings Training { get; set; }
    }
}
