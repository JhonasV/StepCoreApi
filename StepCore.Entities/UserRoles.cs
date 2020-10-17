using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StepCore.Entities
{
    public class UserRoles : Entitie
    {
        [Required]
        public int UsersId { get; set; }
        [Required]
        public int RolesId { get; set; }

        public virtual Users User { get; set; }
        public virtual Roles Role { get; set; }
    }
}
