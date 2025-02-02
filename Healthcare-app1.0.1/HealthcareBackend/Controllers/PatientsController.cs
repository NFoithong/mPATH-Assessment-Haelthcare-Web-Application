using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using HealthBackend.Data;
using HealthBackend.Models;

namespace HealthBackend.Controllers
{
    [Route("api/patients")]
    [ApiController]
    [Authorize(Roles = "Admin, HealthcareProfessional")]
    public class PatientsController : ControllerBase
    {
        private readonly HealthcareDbContext _context;

        public PatientsController(HealthcareDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetPatients()
        {
            var patients = _context.Patients.ToList();
            return Ok(patients);
        }

        [HttpGet("{id}")]
        public IActionResult GetPatient(int id)
        {
            var patient = _context.Patients.Find(id);
            if (patient == null) return NotFound();
            return Ok(patient);
        }
    }
}
