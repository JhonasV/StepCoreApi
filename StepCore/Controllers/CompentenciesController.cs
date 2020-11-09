using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using StepCore.Entities;
using StepCore.Framework.Extensions;
using StepCore.Services.Interfaces;
using StepCore.Services.Repositories;

namespace StepCore.Controllers
{
    [Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CompentenciesController : ControllerBase
    {
        private readonly ICompentenciesRepository _compentenciesRepository;

        public CompentenciesController(ICompentenciesRepository compentenciesRepository)
        {
            _compentenciesRepository = compentenciesRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _compentenciesRepository.GetAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _compentenciesRepository.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create(Compentencies skills)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            await _compentenciesRepository.CreateAsync(skills);
            return Ok(await _compentenciesRepository.SaveAsync());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([Required] int id, Compentencies compentencies)
        {
            if(!ModelState.IsValid || id != compentencies.Id)
                 return BadRequest(ModelState);

            _compentenciesRepository.Update(compentencies);
            return Ok(await _compentenciesRepository.SaveAsync());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([Required] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            await _compentenciesRepository.RemoveAsync(id);
            return Ok(await _compentenciesRepository.SaveAsync());
        }

    }
}