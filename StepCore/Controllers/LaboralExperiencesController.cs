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
        private readonly ILaborExperiencesRepository _laborExperiencescRepository;

        public LaborExperiencesController(ILaborExperiencesRepository laborExperiencescRepository)
        {
            _laborExperiencescRepository = laborExperiencescRepository;   
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _laborExperiencescRepository.GetAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _laborExperiencescRepository.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create(LaborExperiences LaborExperiences)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            await _laborExperiencescRepository.CreateAsync(LaborExperiences);
            return Ok(await _laborExperiencescRepository.SaveAsync());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([Required] int id, LaborExperiences laborExperiences)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != laborExperiences.Id)
                return NotFound();

            _laborExperiencescRepository.Update(laborExperiences);
            return Ok(await _laborExperiencescRepository.SaveAsync());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([Required] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _laborExperiencescRepository.RemoveAsync(id);
            return Ok(await _laborExperiencescRepository.SaveAsync());
        }

        [HttpGet("GetListByUserId/{userId}")]
        public async Task<IActionResult> GetListByUserId(int userId)
        {
            var result = await _laborExperiencescRepository.GetListByUserId(userId);

            return Ok(result);
        }
    }
}