using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using HealthBackend.Data;
using HealthBackend.Models;
using System.Threading.Tasks;
using System;

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

        //Supports search by name or ID
        //Implements pagination(default page size = 10)
        [HttpGet]
        public async Task<IActionResult> GetPatients(
            [FromQuery] string? search,
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 10)
        {
            var query = _context.Patients.AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(p => p.Name.Contains(search) || p.MedicalRecordNumber.Contains(search));
            }

            var totalPatients = await query.CountAsync();
            var patients = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return Ok(new
            {
                totalItems = totalPatients,
                totalPages = (int)Math.Ceiling(totalPatients / (double)pageSize),
                data = patients
            });
        }

    }
}
