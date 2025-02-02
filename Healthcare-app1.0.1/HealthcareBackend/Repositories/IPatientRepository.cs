using System.Collections.Generic;
using System.Threading.Tasks;
using HealthBackend.Models;

namespace HealthBackend.Repositories
{
	public interface IPatientRepository
	{
		Task<IEnumerable<Patient>> GetAllPatientsAsync();
		Task<Patient> GetPatientByIdAsync(int id);
	}
}
