using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StepCore.Entities;
using StepCore.Services.Interfaces;
using StepCore.Services.Repositories;

namespace StepCore.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        private readonly ILogger<SkillsController> _logger;
        private readonly ISkillsRepository _skillsRepository;

        public SkillsController(ILogger<SkillsController> logger, ISkillsRepository skillsRepository)
        {
            _logger = logger;
            _skillsRepository = skillsRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _skillsRepository.Get());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _skillsRepository.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create(Skills skills)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(await _skillsRepository.Create(skills));
        }
    }
}