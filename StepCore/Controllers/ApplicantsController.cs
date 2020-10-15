using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StepCore.Entities;
using StepCore.Services.Interfaces;

namespace StepCore.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ApplicantsController : ControllerBase
    {
        private readonly IApplicantsRepository _applicantsRepository;

        public ApplicantsController(IApplicantsRepository applicantsRepository)
        {
            _applicantsRepository = applicantsRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok( _applicantsRepository.GetWithIncludes());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _applicantsRepository.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create(Applicants applicants)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            await _applicantsRepository.CreateAsync(applicants);
            return Ok(await _applicantsRepository.SaveAsync());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([Required] int id, Applicants applicants)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != applicants.Id)
                return NotFound();

            _applicantsRepository.Update(applicants);
            return Ok(await _applicantsRepository.SaveAsync());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([Required] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _applicantsRepository.RemoveAsync(id);
            return Ok(await _applicantsRepository.SaveAsync());
        }

        [HttpPost("compentencies")]
        public async Task<IActionResult> AddCompetenciesRel(ApplicantsCompentencies applicantsCompentencies)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(await _applicantsRepository.AddCompentenciesRel(applicantsCompentencies));
        }


        [HttpPost]
        [Route("trainings")]
        public async Task<IActionResult> AddTrainingsRel(ApplicantsTrainings applicantsTrainings)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(await _applicantsRepository.AddTrainingsRel(applicantsTrainings));
        }

        [HttpPost]
        [Route("laborexperiences")]
        public async Task<IActionResult> AddLaborExperiencesRel(ApplicantsLaborExperiences applicantsLaborExperiences)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(await _applicantsRepository.AddLaborExperiencesRel(applicantsLaborExperiences));
        }
    }
}