using Microsoft.AspNetCore.Mvc;
using HealthcareAPI.Data;
using HealthcareAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HealthcareAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly HealthcareContext _context;

        public PatientController(HealthcareContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Patient>>> GetPatients()
        {
            return await _context.Patients.Include(p => p.Recommendations).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Patient>> GetPatient(int id)
        {
            var patient = await _context.Patients.Include(p => p.Recommendations)
                                                 .FirstOrDefaultAsync(p => p.PatientId == id);
            if (patient == null) return NotFound();
            return patient;
        }

        [HttpPost]
        public async Task<ActionResult<Patient>> AddPatient(Patient patient)
        {
            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetPatient), new { id = patient.PatientId }, patient);
        }

        //Protect API Routes to restrict access based on roles
        [Authorize(Roles = "Admin,HealthcareProfessional")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Patient>>> GetPatients()
        {
            return await _context.Patients.Include(p => p.Recommendations).ToListAsync();
        }

    }
}
