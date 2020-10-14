using StepCore.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StepCore.Entities
{
    public class JobPositions : Entitie
    {
        [Required, StringLength(50)]
        public string Name { get; set; }
        [Required, StringLength(15)]
        public string RiskLevel { get; set; }
        [Required]
        public double SalaryMinLevel { get; set; }
        [Required]
        public double SalaryMaxLevel { get; set; }
        [Required]
        [RegularExpression("^[0-1]{1}$", ErrorMessage = "The value provided is no valid, must be 0 or 1")]
        public int Status { get; set; } = (int)Enums.Entities.Status.ENABLE;
    }
}
