using Microsoft.EntityFrameworkCore;
using HealthcareBackend.Data;
using HealthcareBackend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HealthcareBackend.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly HealthcareDbContext _context;

        public PatientRepository(HealthcareDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Patient>> GetAllPatientsAsync()
        {
            return await _context.Patients.Include(p => p.Recommendations).ToListAsync();
        }

        public async Task<Patient> GetPatientByIdAsync(int id)
        {
            return await _context.Patients.Include(p => p.Recommendations).FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
