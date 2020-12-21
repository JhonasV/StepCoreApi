using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StepCore.Entities;
using StepCore.Framework;
using StepCore.Framework.Extensions;
using StepCore.Framework.Models.Applicants;
using StepCore.Services.Interfaces;

namespace StepCore.Controllers
{
    [Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ApplicantsController : ControllerBase
    {
        private readonly IApplicantsRepository _applicantsRepository;
        private readonly IUsersRepository _usersRepository;

        public ApplicantsController(IApplicantsRepository applicantsRepository, IUsersRepository usersRepository)
        {
            _applicantsRepository = applicantsRepository;
            _usersRepository = usersRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var currentUser = this.CurrentUser();
            currentUser.Roles = await _usersRepository.GetUserRolesAsync(currentUser.Id);
            var result = await _applicantsRepository.GetWithIncludesAsync(currentUser);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _applicantsRepository.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create(ApplicantsCreateModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var currentUser = this.CurrentUser();
            model.Applicants.UsersId = currentUser.Id;
            var result  = await _applicantsRepository.CreateAsync(model.Applicants);

            if (!result.Success)
            {
                return Ok(result);
            }
            model.ApplicantsTrainings = model.ApplicantsTrainings.Select((item) => new ApplicantsTrainings { ApplicantsId = result.Data, TrainingsId = item.TrainingsId }).ToList();
            var appTrainResult = await _applicantsRepository.AddTrainingsRelAsync(model.ApplicantsTrainings);

            if (!appTrainResult.Success)
            {
                return Ok(appTrainResult);
            }

            model.ApplicantsCompentencies = model.ApplicantsCompentencies.Select((item) => new ApplicantsCompentencies { ApplicantsId = result.Data, CompentenciesId = item.CompentenciesId }).ToList();
            var appCompResult = await _applicantsRepository.AddCompentenciesRelAsync(model.ApplicantsCompentencies);

            if (!appCompResult.Success)
            {
                return Ok(appCompResult);
            }

            model.ApplicantsLaborExperiences = model.ApplicantsLaborExperiences.Select((item) => new ApplicantsLaborExperiences { ApplicantsId = result.Data, LaborExperiencesId = item.LaborExperiencesId }).ToList();
            var appLabExpResult = await _applicantsRepository.AddLaborExperiencesRelAsync(model.ApplicantsLaborExperiences);

            if (!appLabExpResult.Success)
            {
                return Ok(appLabExpResult);
            }

            return Ok(result);
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

            result = _applicantsRepository.Update(applicants);
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
        public async Task<IActionResult> AddCompetenciesRel(List<ApplicantsCompentencies> applicantsCompentencies)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(await _applicantsRepository.AddCompentenciesRelAsync(applicantsCompentencies));
        }


        [HttpPost("trainings")]
        public async Task<IActionResult> AddTrainingsRel(List<ApplicantsTrainings> applicantsTrainings)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(await _applicantsRepository.AddTrainingsRelAsync(applicantsTrainings));
        }

        [HttpPost("laborexperiences")]
        public async Task<IActionResult> AddLaborExperiencesRel(List<ApplicantsLaborExperiences> applicantsLaborExperiences)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(await _applicantsRepository.AddLaborExperiencesRelAsync(applicantsLaborExperiences));
        }

        [HttpDelete("compentencies/{id}")]
        public async Task<IActionResult> RemoveCompetenciesRel([Required]int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(await _applicantsRepository.RemoveApplicantCompentenciesRelAsync(id));
        }


        [HttpDelete("trainings/{id}")]
        public async Task<IActionResult> RemoveTrainingsRel([Required]int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(await _applicantsRepository.RemoveApplicantTrainingsRelAsync(id));
        }

        [HttpDelete("laborexperiences/{id}")]
        public async Task<IActionResult> RemoveLaborExperiencesRel([Required]int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(await _applicantsRepository.RemoveApplicantTrainingsRelAsync(id));
        }
    }
}