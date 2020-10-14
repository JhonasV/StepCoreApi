using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StepCore.Entities
{
    public class Applicants : Entitie
    {
        [Required, StringLength(20)]
        public string DocumentNumber { get; set; }
        [Required, StringLength(100)]
        public string Name { get; set; }
        [Required]
        public int JobPositionsId { get; set; }
        [Required, StringLength(50)]
        public string Department { get; set; }
        [Required]
        public double SalaryAspiration { get; set; }
        public int CompentenciesId { get; set; }
        [Required]
        public int TrainingsId { get; set; }
        public int LaborExperiencesId { get; set; }
        [Required, StringLength(50)]
        public string RecommendedBy { get; set; }
        public virtual List<Compentencies> Compentencies { get; set; } = new List<Compentencies>();
        public virtual List<Trainings> Trainings { get; set; } = new List<Trainings>();
        public virtual List<LaborExperiences> LaborExperiences { get; set; } = new List<LaborExperiences>();
    }
}
