using StepCore.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StepCore.Entities
{
    public class Employees : Entitie
    {

        [Required, StringLength(20)]
        public string DocumentId { get; set; }
        [Required, StringLength(100)]
        public string Name { get; set; }
        
        public DateTime DateOfAdmission { get; set; }
        [Required, StringLength(50)]
        public string Department { get; set; }
        [Required]
        public int JobPositionsId { get; set; }
        [Required]
        public double MonthSalary { get; set; }
        [Required]
        [RegularExpression("^[0-1]{1}$", ErrorMessage = "The value provided is no valid, must be 0 or 1")]
        public int Status { get; set; } = (int)Enums.Entities.Status.ENABLE;
        public virtual JobPositions JobPositions { get; set; }
    }
}
