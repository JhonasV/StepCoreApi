using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StepCore.Entities;
using StepCore.Services.Interfaces;

namespace StepCore.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class LanguagesController : ControllerBase
    {
        private readonly IGenericRepository<Languages> _genericRepository;

        public LanguagesController(IGenericRepository<Languages> genericRepository)
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
        public async Task<IActionResult> Create(Languages languages)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(await _genericRepository.CreateAsync(languages));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([Required] int id, Languages languages)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != languages.Id)
                return NotFound();

            await _genericRepository.UpdateAsync(languages);
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