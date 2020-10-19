using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StepCore.Entities;
using StepCore.Services.Interfaces;

namespace StepCore.Controllers
{
    [Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRolesRepository _rolesRepository;

        public RolesController(IRolesRepository rolesRepository)
        {
            _rolesRepository = rolesRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _rolesRepository.GetAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _rolesRepository.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create(Roles role)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            await _rolesRepository.CreateAsync(role);
            return Ok(await _rolesRepository.SaveAsync());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([Required] int id, Roles role)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != role.Id)
                return NotFound();

            _rolesRepository.Update(role);
            return Ok(await _rolesRepository.SaveAsync());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([Required] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _rolesRepository.RemoveAsync(id);
            return Ok(await _rolesRepository.SaveAsync());
        }
    }
}