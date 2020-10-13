using StepCore.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StepCore.Entities
{
    public class Compentencies : Entitie
    {
        [Required, StringLength(400)]
        public string Description { get; set; }
        [Required]
        [RegularExpression("^[0-1]{1}$", ErrorMessage = "The value provided is no valid, must be 0 or 1")]
        public int Status { get; set; } = (int)Enums.Entities.Status.ENABLE;
    }
}
