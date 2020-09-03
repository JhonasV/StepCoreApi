using Microsoft.EntityFrameworkCore;
using StepCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StepCore
{
    public class StepCoreContext : DbContext
    {
        public StepCoreContext(DbContextOptions<StepCoreContext> options)
            :base(options)
        {

        }

        public DbSet<Skills> Skills { get; set; }
    }
}
