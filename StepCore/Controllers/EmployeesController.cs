using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StepCore.Entities;
using StepCore.Services.Interfaces;

namespace StepCore.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IGenericRepository<Employees> _genericRepository;

        public EmployeesController(IGenericRepository<Employees> genericRepository)
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
        public async Task<IActionResult> Create(Employees Employees)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            await _genericRepository.CreateAsync(Employees);
            return Ok(await _genericRepository.SaveAsync());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([Required] int id, Employees employees)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != employees.Id)
                return NotFound();

            await _genericRepository.UpdateAsync(employees);
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