using Microsoft.Extensions.Options;
using StepCore.Data.Models;
using StepCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static StepCore.Data.Framework.Constants;

namespace StepCore.Data
{
    public static class Seed
    {
        public static void Initialiaze(StepCoreContext stepCoreContext, SeedSettings _seedConfig)
        {
            var usersExists = stepCoreContext.Users.Any();

            if (!usersExists)
            {

                var roleAdmin = new Roles
                {
                    Name = RolesConstants.ADMIN
                };

                var roleApplicant = new Roles
                {
                    Name = RolesConstants.APPLICANT
                };

                var roles = new List<Roles>
                {
                    roleAdmin,
                    roleApplicant
                };

                stepCoreContext.Roles.AddRange(roles);
                stepCoreContext.SaveChanges();

                var user = new Users
                {
                    UserName = _seedConfig.User,
                    Password = _seedConfig.Password
                };

                stepCoreContext.Users.Add(user);
                stepCoreContext.SaveChanges();

                var userRolesAdmin = new UserRoles
                {
                    RolesId = roleAdmin.Id,
                    UsersId = user.Id
                };

                var userRolesApplicant = new UserRoles
                {
                    RolesId = roleApplicant.Id,
                    UsersId = user.Id
                };

                var userRoles = new List<UserRoles>
                {
                    userRolesApplicant,
                    userRolesAdmin
                };

                stepCoreContext.UserRoles.AddRange(userRoles);
                stepCoreContext.SaveChanges();
            }
        }
    }
}
