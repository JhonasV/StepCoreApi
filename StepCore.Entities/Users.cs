using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace StepCore.Entities
{
    public class Users : Entitie
    {
        public Users()
        {
            Roles = new HashSet<Roles>();
        }

        [Required, StringLength(30), MinLength(5)]
        public string UserName { get; set; }
        [Required, StringLength(30), MinLength(5)]
        public string Password { get; set; }

        [NotMapped]
        public virtual ICollection<Roles> Roles { get; set; }
    }
}
