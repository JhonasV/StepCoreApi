using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace StepCore.Entities
{
    public class LaborExperiences : Entitie
    {
        [Required, StringLength(50)]
        public string Company { get; set; }
        [Required, StringLength(50)]
        public string Position { get;  set; }
        [Required]
        [ForeignKey("Users")]
        public int UserId { get; set; }
        [Required]
        public DateTime InitialDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public double Salary { get; set; }
        public virtual Users Users { get; set; }
    }
}
