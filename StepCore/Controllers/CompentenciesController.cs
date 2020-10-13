using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using StepCore.Entities;
using StepCore.Services.Interfaces;
using StepCore.Services.Repositories;

namespace StepCore.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CompentenciesController : ControllerBase
    {
        private readonly ILogger<CompentenciesController> _logger;
        private readonly ICompentenciesRepository _compentenciesRepository;

        public CompentenciesController(ILogger<CompentenciesController> logger, ICompentenciesRepository compentenciesRepository)
        {
            _logger = logger;
            _compentenciesRepository = compentenciesRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _compentenciesRepository.Get());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _compentenciesRepository.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create(Compentencies skills)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(await _compentenciesRepository.Create(skills));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([Required] int id, Compentencies compentencies)
        {
            if(!ModelState.IsValid)
                 return BadRequest(ModelState);

            return Ok(await _compentenciesRepository.Update(id, compentencies));
        }
    }
}