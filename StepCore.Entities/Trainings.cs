using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StepCore.Entities
{
    public class Trainings : Entitie
    {
        [Required, MaxLength(100)]
        public string Description { get; set; }
        [Required, MaxLength(100)]
        public string Level { get; set; }
        public DateTime InitialDate { get; set; }
        public DateTime EndDate { get; set; }
        [Required, MaxLength(100)]
        public string Academy { get; set; }
    }
}
