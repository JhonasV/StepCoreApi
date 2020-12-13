using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using StepCore.Entities;
using StepCore.Framework;
using StepCore.Framework.Extensions;
using StepCore.Framework.Models;
using StepCore.Framework.Security;
using StepCore.Services.Interfaces;
using static StepCore.Framework.Constants;

namespace StepCore.Controllers
{
    [Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IUsersRepository _usersRepository;
        private readonly IJwtAuthenticationManager _jwtAuthenticationManager;
        private readonly IRolesRepository _rolesRepository;

        public AuthController(IUsersRepository usersRepository, IJwtAuthenticationManager jwtAuthenticationManager, IRolesRepository rolesRepository)
        {
            _usersRepository = usersRepository;
            _jwtAuthenticationManager = jwtAuthenticationManager;
            _rolesRepository = rolesRepository;
        }
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(Users user)
        {

            if (!ModelState.IsValid)
            {   
                return BadRequest(new BadRequestObjectResult(ModelState));
            }

            var usr = await _usersRepository.GetByUserNameAsync(user.UserName);
            var result = new TaskResult<string>();

            if(usr != null)
            {
                if (usr.Password == user.Password)
                {
                    result.Data = _jwtAuthenticationManager.Authenticate(usr);
                    return Ok(result);
                }
            }

            result.AddErrorMessage("Usuario y/o password inválido");
            return Unauthorized(result);
        }
        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register(Users user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = new TaskResult<string>();
            var usr = await _usersRepository.GetByUserNameAsync(user.UserName);

            if(usr == null)
            {

                var roleResult = await _rolesRepository.GetByNameAsync(RolesConstants.APPLICANT);
                if (!roleResult.Success)
                {
                    roleResult.AddErrorMessage($"El role {RolesConstants.APPLICANT} no existe");
                    return BadRequest(roleResult);
                }

                await _usersRepository.CreateAsync(user);
                var createdSuccesfully = await _usersRepository.SaveAsync();
                if (!createdSuccesfully)
                {
                    result.AddErrorMessage($"No se pudo crear el usuario: {user.UserName}");
                    return BadRequest(result);
                }
   
                var roleAdded = await _usersRepository.AddUserRole(roleResult.Data.Id, user.Id);
                if (!roleAdded)
                {
                    result.AddErrorMessage($"No se pudo agregar el rol {roleResult.Data.Name} al usuario {user.UserName}");
                    return BadRequest(result);
                }

                result.Data = _jwtAuthenticationManager.Authenticate(user);
                return Ok(result);
            }

            result.AddErrorMessage("El nombre de usuario ingresado ya se encuentra registrado");
            return BadRequest(result);
        }

        [Authorize]
        [HttpPost("user/role")]
        public async Task<IActionResult> AddUserRole(AddUserRoleModel model)
        {
            var result = new TaskResult<string>();

            var userResult = await _usersRepository.GetByIdAsync(model.UserId);
            if(userResult.Data == null)
            {
                userResult.AddErrorMessage("El usuario no existe");
                return BadRequest(userResult);
            }

            var roleResult = await _rolesRepository.GetByNameAsync(model.RoleName);
            if (roleResult.Data == null)
            {
                roleResult.AddErrorMessage("El role no existe");
                return BadRequest(roleResult);
            }

            var added = await _usersRepository.AddUserRole(roleResult.Data.Id, userResult.Data.Id);
            if (!added)
            {
                result.AddErrorMessage($"Error al agregar el rol {model.RoleName} al usuario {userResult.Data.UserName}");
                return Ok(result);
            }

            result.AddMessage($"Se agregó exitosamente el rol {model.RoleName} al usuario {userResult.Data.UserName}");
            return Ok(result);
        }

        [HttpGet("current")]
        public async Task<IActionResult> Current()
        {
            var currentUser =  this.CurrentUser();
            currentUser.Roles = await _usersRepository.GetUserRolesAsync(currentUser.Id);
            var result = new TaskResult<Users>();
            result.Data = currentUser;
            return Ok(result);
        }

    }
}