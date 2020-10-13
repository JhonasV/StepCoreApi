using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StepCore.Entities;
using StepCore.Services.Interfaces;

namespace StepCore.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class LanguagesController : ControllerBase
    {
        private readonly ILogger<LanguagesController> _logger;
        private readonly ILanguagesRepository _languageRepository;

        public LanguagesController(ILogger<LanguagesController> logger, ILanguagesRepository languageRepository)
        {
            _logger = logger;
            _languageRepository = languageRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _languageRepository.Get());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _languageRepository.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create(Languages languages)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(await _languageRepository.Create(languages));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([Required] int id, Languages languages)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(await _languageRepository.Update(id, languages));
        }
    }
}