using Microsoft.Extensions.Options;
using StepCore.Data.Models;
using StepCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StepCore.Data
{
    public static class Seed
    {
        public static void Initialiaze(StepCoreContext stepCoreContext, SeedConfig _seedConfig)
        {
            var usersExists = stepCoreContext.Users.Any();

            if (!usersExists)
            {

                var roleAdmin = new Roles
                {
                    Name = _seedConfig.RoleAdmin
                };

                var roleApplicant = new Roles
                {
                    Name = _seedConfig.RoleApplicant
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
