using Microsoft.EntityFrameworkCore;
using HealthcareApi.Models;

namespace HealthcareApi.Data
{
    public class HealthcareContext : DbContext
    {
        public HealthcareContext(DbContextOptions<HealthcareContext> options)
            : base(options)
        {
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Recommendation> Recommendations { get; set; }
    }
}
