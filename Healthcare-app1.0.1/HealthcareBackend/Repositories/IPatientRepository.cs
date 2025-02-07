using System.Collections.Generic;
using System.Threading.Tasks;
using HealthcareBackend.Models;

namespace HealthcareBackend.Repositories
{
	public interface IPatientRepository
	{
		Task<IEnumerable<Patient>> GetAllPatientsAsync();
		Task<Patient> GetPatientByIdAsync(int id);
	}
}
