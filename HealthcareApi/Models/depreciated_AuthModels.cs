namespace HealthcareAPI.Models
{
    public class RegisterModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }  // Admin, HealthcareProfessional
    }

    public class LoginModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
