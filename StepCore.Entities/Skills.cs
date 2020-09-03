using StepCore.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StepCore.Entities
{
    public class Skills : Entitie
    {
        [Required, StringLength(400)]
        public string Description { get; set; }
        public int Status { get; set; } = (int)Enums.Entities.Status.ENABLE;
    }
}
