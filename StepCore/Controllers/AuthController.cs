using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StepCore.Entities;
using StepCore.Framework;
using StepCore.Framework.Security;
using StepCore.Services.Interfaces;

namespace StepCore.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IUsersRepository _usersRepository;
        private readonly IJwtAuthenticationManager _jwtAuthenticationManager;

        public AuthController(IUsersRepository usersRepository, IJwtAuthenticationManager jwtAuthenticationManager)
        {
            _usersRepository = usersRepository;
            _jwtAuthenticationManager = jwtAuthenticationManager;
        }

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
            return Ok(result);
        }

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
                result.Data = _jwtAuthenticationManager.Authenticate(user);
                return Ok(result);
            }

            result.AddErrorMessage("El nombre de usuario ingresado ya se encuentra registrado");
            return Ok(result);
        }
    }
}