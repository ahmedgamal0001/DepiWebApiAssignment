using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Dtos.PatientDtos;
using WebApplication2.Entities;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")] 
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly ApplicationDbContext _dbcontext;

        public PatientsController(ApplicationDbContext Dbcontext)
        {
            _dbcontext = Dbcontext;
        }

        [HttpGet("GetAllPatient")]
        public async Task<IActionResult> GetAllPatient()
        {
            var Patients = await _dbcontext.Patients.ToListAsync();

            var responses = new List < GetPatientResponse >();
            foreach (var patient in Patients)
            {
                var response = new GetPatientResponse
                {
                    ID = patient.ID,
                    Name = patient.Name,
                    DateOfBirth = patient.DateOfBirth
                };

                responses.Add(response);
            }
            return Ok(responses);
        }

        [HttpGet("GetPatientByID/{id:int}")]
        public async Task<IActionResult> GetPatientByID(int id)
        {
            var Patient = await _dbcontext.Patients.FirstOrDefaultAsync(p => p.ID == id);
            if (Patient == null)
            {
                return NotFound($"Patient with id {id} not found");
            }

            var response= new GetPatientResponse
            {
                ID = Patient.ID,
                Name = Patient.Name,
                DateOfBirth = Patient.DateOfBirth
            };
            return Ok(response);
        }

        [HttpPost("CreatePatient")]
        public async Task<IActionResult> CreatePatient(CreatePtientRequest request)
        {
            var patient = new Patient
            {
                Name = request.Name,
                DateOfBirth = request.DateOfBirth
            };
            await _dbcontext.Patients.AddAsync(patient);
            await _dbcontext.SaveChangesAsync();
            return Created();
        }

        [HttpPut("UpdatePatient")]
        public async Task<IActionResult> UpdatePatient(UpdatePatientRequest request)
        {
            var Patient = await _dbcontext.Patients.FindAsync(request.ID);
            if (Patient is null)
                return NotFound($"Patient with id {request.ID} not found");

            Patient.Name = request.Name;
            Patient.DateOfBirth = request.DateOfBirth;
            _dbcontext.Patients.Update(Patient);
            await _dbcontext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("DeletePatient")]
        public async Task<IActionResult> DeletePatient(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid patient ID");
            var patient = await _dbcontext.Patients.FindAsync(id);
            if (patient is null)
                return NotFound($"Patient with id {id} not found");
            //_dbcontext.Patients.Remove(patient);
            patient.IsDeleted = true;
            _dbcontext.Update(patient);
            await _dbcontext.SaveChangesAsync();
            return NoContent();
        }
    }
}
