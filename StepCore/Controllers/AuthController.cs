using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StepCore.Entities;
using StepCore.Framework;
using StepCore.Framework.Extensions;
using StepCore.Framework.Security;
using StepCore.Services.Interfaces;

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
            return BadRequest(result);
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
                await _usersRepository.CreateAsync(user);
                await _usersRepository.SaveAsync();
                await _usersRepository.AddUserRole((int)Framework.Roles.APPLICANT, user.Id);
                result.Data = _jwtAuthenticationManager.Authenticate(user);
                return Ok(result);
            }

            result.AddErrorMessage("El nombre de usuario ingresado ya se encuentra registrado");
            return BadRequest(result);
        }

        [Authorize]
        [HttpPost("user/role")]
        public async Task<IActionResult> AddUserRole(UserRoles userRoles)
        {
            var result = new TaskResult<string>();

            var user = await _usersRepository.GetByIdAsync(userRoles.UsersId);
            if(user == null)
            {
                result.AddErrorMessage("El usuario no existe");
                return BadRequest(result);
            }

            var role = await _rolesRepository.GetByIdAsync(userRoles.RolesId);
            if (role == null)
            {
                result.AddErrorMessage("El role no existe");
                return BadRequest(result);
            }

            await _usersRepository.AddUserRole(userRoles.RolesId, userRoles.UsersId);
            return Ok(result);
        }

        [HttpGet("current")]
        public async Task<IActionResult> Current()
        {
            var currentUser =  this.CurrentUser();
            currentUser.Roles = await _usersRepository.GetUserRolesAsync(currentUser.Id);
            return Ok(currentUser);
        }
    }
}