using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StepCore.Entities
{
    public class Roles : Entitie
    {
        [Required, StringLength(30)]
        public string Name { get; set; }
    }
}
