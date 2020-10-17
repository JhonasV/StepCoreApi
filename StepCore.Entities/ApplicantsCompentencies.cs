using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StepCore.Entities
{
    public class ApplicantsCompentencies : Entitie
    {
        [Required]
        public int ApplicantsId { get; set; }
        [Required]
        public int CompentenciesId { get; set; }
        public bool IsPrincipal { get; set; }
        public virtual Applicants Applicant { get; set; }
        public virtual Compentencies Compentencie { get; set; }
    }
}
