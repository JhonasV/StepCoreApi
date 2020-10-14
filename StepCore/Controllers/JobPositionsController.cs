using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StepCore.Entities;
using StepCore.Services.Interfaces;

namespace StepCore.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class JobPositionsController : ControllerBase
    {
        private readonly IGenericRepository<JobPositions> _genericRepository;

        public JobPositionsController(IGenericRepository<JobPositions> genericRepository)
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
        public async Task<IActionResult> Create(JobPositions jobPositions)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            await _genericRepository.CreateAsync(jobPositions);
            return Ok(_genericRepository.SaveAsync().Result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([Required] int id, JobPositions jobPositions)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != jobPositions.Id)
                return NotFound();

            await _genericRepository.UpdateAsync(jobPositions);
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