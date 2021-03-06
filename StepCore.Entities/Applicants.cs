﻿using StepCore.Entities.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace StepCore.Entities
{
    public class Applicants : Entitie
    {
        public Applicants()
        {
            this.Compentencies = new HashSet<Compentencies>();
            this.Trainings = new HashSet<Trainings>();
            this.LaborExperiences = new HashSet<LaborExperiences>();
        }

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
        [StringLength(50)]
        public string RecommendedBy { get; set; }
        [Required, ForeignKey("Users")]
        public int UsersId { get; set; }
        public int Status { get; set; } = (int)Enums.Entities.Status.ENABLE;
        public virtual ICollection<Compentencies> Compentencies { get; set; }
        public virtual ICollection<Trainings> Trainings { get; set; }
        public virtual ICollection<LaborExperiences> LaborExperiences { get; set; }
        [NotMapped]
        public virtual JobPositions JobPositions { get; set; }
    }
}
