using System;
using System.Collections.Generic;
using System.Text;

namespace StepCore.Entities
{
    public class Entitie
    {
        public int Id { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; }

    }
}
