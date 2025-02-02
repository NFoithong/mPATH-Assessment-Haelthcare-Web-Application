using System.Collections.Generic;
using System.Threading.Tasks;
using HealthcareApi.Data;
using HealthcareApi.Models;
using Microsoft.EntityFrameworkCore;

namespace HealthcareApi.Repositories
{
    public class PatientRepository
    {
        private readonly HealthcareContext _context;

        public PatientRepository(HealthcareContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Patient>> GetPatientsAsync(string searchTerm, int page, int pageSize)
        {
            return await _context.Patients
                .Where(p => p.Name.Contains(searchTerm))
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<Patient> GetPatientByIdAsync(int id)
        {
            return await _context.Patients.Include(p => p.Recommendations)
                .FirstOrDefaultAsync(p => p.PatientId == id);
        }
    }
}
