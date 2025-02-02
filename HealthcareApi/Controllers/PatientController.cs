using HealthcareApi.Models;
using HealthcareApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace HealthcareApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly PatientService _patientService;

        public PatientsController(PatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Patient>>> GetPatients(string searchTerm, int page = 1, int pageSize = 10)
        {
            var patients = await _patientService.GetPatientsAsync(searchTerm, page, pageSize);
            return Ok(patients);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Patient>> GetPatient(int id)
        {
            var patient = await _patientService.GetPatientByIdAsync(id);
            if (patient == null)
                return NotFound();

            return Ok(patient);
        }

    }

}
