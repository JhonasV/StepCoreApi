using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StepCore.Entities;
using StepCore.Entities.Framework;
using StepCore.Framework;
using StepCore.Services.Interfaces;

namespace StepCore.Controllers
{
    [Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IGenericRepository<Employees> _genericRepository;
        private readonly IApplicantsRepository _applicantsRepository;

        public EmployeesController(IGenericRepository<Employees> genericRepository, IApplicantsRepository applicantsRepository)
        {
            _genericRepository = genericRepository;
            _applicantsRepository = applicantsRepository;
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
        public async Task<IActionResult> Create(Applicants applicants)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var resultApplicant =  await _applicantsRepository.GetByIdAsync(applicants.Id);
            var applicant = resultApplicant.Data;
            var newEmployee = new Employees();
            if (resultApplicant.Success)
            {
                
                applicant.Status = (int)Enums.Entities.Status.DISABLE;
                 _applicantsRepository.Update(applicant);

                newEmployee.JobPositionsId = applicant.JobPositionsId;
                newEmployee.MonthSalary = applicant.SalaryAspiration;
                newEmployee.Name = applicant.Name;
                newEmployee.DocumentNumber = applicant.DocumentNumber;
                newEmployee.DateOfAdmission = DateTime.Now;
                newEmployee.Department = applicant.Department;
            }
            var result = new TaskResult<bool>();
        
            try
            {
                await _genericRepository.CreateAsync(newEmployee);
                result.Data = await _genericRepository.SaveAsync();
            }
            catch (Exception e)
            {

                result.AddErrorMessage(e.Message);
            }
            
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([Required] int id, Employees employees)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != employees.Id)
                return NotFound();

             _genericRepository.Update(employees);
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