using Microsoft.AspNetCore.Identity;

namespace HealthcareAPI.Models
{
    public class User : IdentityUser
    {
        public string Role { get; set; }  // Admin, HealthcareProfessional
    }
}
