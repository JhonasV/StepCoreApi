using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StepCore.Framework.Models
{
    public class AddUserRoleModel
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public string RoleName{ get; set; }
    }
}
