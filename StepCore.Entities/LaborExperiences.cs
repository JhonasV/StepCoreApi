using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StepCore.Entities
{
    public class LaborExperiences : Entitie
    {
        [Required, StringLength(50)]
        public string Company { get; set; }
        [Required]
        public int JobPositionsId { get; set; }
        [Required]
        public DateTime InitialDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public double Salary { get; set; }
        public virtual JobPositions JobPositions { get; set; }
    }
}
