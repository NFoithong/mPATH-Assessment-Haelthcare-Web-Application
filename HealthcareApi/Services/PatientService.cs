using System.Collections.Generic;
using System.Threading.Tasks;
using HealthcareApi.Models;
using HealthcareApi.Repositories;

namespace HealthcareApi.Services
{
    public class PatientService
    {
        private readonly PatientRepository _repository;

        public PatientService(PatientRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<Patient>> GetPatientsAsync(string searchTerm, int page, int pageSize)
        {
            return _repository.GetPatientsAsync(searchTerm, page, pageSize);
        }

        public Task<Patient> GetPatientByIdAsync(int id)
        {
            return _repository.GetPatientByIdAsync(id);
        }
    }
}
