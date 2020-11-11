using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StepCore.Entities;
using StepCore.Framework.Extensions;
using StepCore.Services.Interfaces;

namespace StepCore.Controllers
{
    [Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class LaborExperiencesController : ControllerBase
    {
        private readonly IGenericRepository<LaborExperiences> _genericRepository;

        public LaborExperiencesController(IGenericRepository<LaborExperiences> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _genericRepository.GetAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _genericRepository.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create(LaborExperiences LaborExperiences)
        {
            LaborExperiences.UserId = this.CurrentUser().Id;
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            await _genericRepository.CreateAsync(LaborExperiences);
            return Ok(await _genericRepository.SaveAsync());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([Required] int id, LaborExperiences laborExperiences)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != laborExperiences.Id)
                return NotFound();

             _genericRepository.Update(laborExperiences);
            return Ok(await _genericRepository.SaveAsync());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([Required] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _genericRepository.RemoveAsync(id);
            return Ok(await _genericRepository.SaveAsync());
        }
    }
}