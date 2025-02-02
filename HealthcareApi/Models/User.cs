//Define User Roles
//We will define roles such as Admin and Healthcare Professional.

//Admin: Can manage users, patients, and recommendations.
//Healthcare Professional: Can view and update patient recommendations.


using Microsoft.AspNetCore.Identity;

namespace HealthcareAPI.Models
{
    public class User : IdentityUser
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; } // Store hashed passwords
        public string Role { get; set; }  // Admin, HealthcareProfessional
    }
}
