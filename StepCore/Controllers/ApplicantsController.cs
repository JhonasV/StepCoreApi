using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StepCore.Entities;
using StepCore.Framework;
using StepCore.Services.Interfaces;

namespace StepCore.Controllers
{
    [Authorize]
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
            var result = new TaskResult<Applicants>();
            if (id != applicants.Id)
            {
                result.AddErrorMessage("Los identificadores no coinciden");
                return Ok(result);
            }

            result.Data = _applicantsRepository.Update(applicants);
            await _applicantsRepository.SaveAsync();
            return Ok(result);
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


        [HttpPost("trainings")]
        public async Task<IActionResult> AddTrainingsRel(ApplicantsTrainings applicantsTrainings)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(await _applicantsRepository.AddTrainingsRel(applicantsTrainings));
        }

        [HttpPost("laborexperiences")]
        public async Task<IActionResult> AddLaborExperiencesRel(ApplicantsLaborExperiences applicantsLaborExperiences)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(await _applicantsRepository.AddLaborExperiencesRel(applicantsLaborExperiences));
        }

        [HttpDelete("compentencies/{id}")]
        public async Task<IActionResult> RemoveCompetenciesRel([Required]int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(await _applicantsRepository.RemoveApplicantCompentenciesRel(id));
        }


        [HttpDelete("trainings/{id}")]
        public async Task<IActionResult> RemoveTrainingsRel([Required]int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(await _applicantsRepository.RemoveApplicantTrainingsRel(id));
        }

        [HttpDelete("laborexperiences/{id}")]
        public async Task<IActionResult> RemoveLaborExperiencesRel([Required]int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(await _applicantsRepository.RemoveApplicantTrainingsRel(id));
        }
    }
}