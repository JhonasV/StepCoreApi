﻿using Microsoft.EntityFrameworkCore;
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

        public DbSet<Compentencies> Compentencies { get; set; }
        public DbSet<Languages> Languages { get; set; }
        public DbSet<Trainings> Trainings { get; set; }
        public DbSet<JobPositions> JobPositions { get; set; }
        public DbSet<Applicants> Applicants { get; set; }
        public DbSet<LaborExperiences> LaborExperiences { get; set; }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<ApplicantsCompentencies> ApplicantsCompentencies { get; set; }
        public DbSet<ApplicantsLaborExperiences> ApplicantsLaborExperiences { get; set; }
        public DbSet<ApplicantsTrainings> ApplicantsTrainings { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<UserRoles> UserRoles { get; set; }
    }
}
