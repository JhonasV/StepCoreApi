using Microsoft.AspNetCore.Mvc;
using StepCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace StepCore.Framework.Extensions
{
    public static class ControllersExtension
    {

        public static Users CurrentUser(this ControllerBase controllerBase)
        {
            var currentUser = new Users
            {
                Id = int.Parse(controllerBase.User.Claims.First(i => i.Type == ClaimTypes.NameIdentifier).Value),
                UserName = controllerBase.User.Claims.First(i => i.Type == ClaimTypes.Name).Value
            };

            return currentUser;
        }
    }
}
