using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StepCore.Entities;
using StepCore.Services.Interfaces;

namespace StepCore.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TrainingsController : ControllerBase
    {
        private readonly IGenericRepository<Trainings> _genericRepository;

        public TrainingsController(IGenericRepository<Trainings> genericRepository)
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
        public async Task<IActionResult> Create(Trainings training)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            await _genericRepository.CreateAsync(training);
            return Ok(_genericRepository.SaveAsync().Result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([Required] int id, Trainings trainings)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != trainings.Id)
                return NotFound();

             _genericRepository.Update(trainings);
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