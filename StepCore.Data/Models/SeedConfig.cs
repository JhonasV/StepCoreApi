using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StepCore.Data.Models
{
    public class SeedConfig
    {
        public string User { get; set; }
        public string Password { get; set; }
        public string RoleAdmin { get; set; }
        public string RoleApplicant { get; set; }
    }
}
