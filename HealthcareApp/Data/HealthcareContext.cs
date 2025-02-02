//Configure Entity Framework (Database Context)
//Configure Identity & Authentication

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using HealthcareAPI.Models;

namespace HealthcareAPI.Data
{
    public class HealthcareContext : IdentityDbContext<User>
    {
        public HealthcareContext(DbContextOptions<HealthcareContext> options) : base(options)
        {
            // Constructor body (if needed, can include additional initialization logic here)
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Recommendation> Recommendations { get; set; }
    }
}
