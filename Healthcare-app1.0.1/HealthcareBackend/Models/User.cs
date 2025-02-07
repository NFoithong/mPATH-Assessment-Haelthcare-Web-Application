using System.ComponentModel.DataAnnotations;

namespace HealthcareBackend.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Username { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        [Required]
        [MaxLength(20)]
        public string Role { get; set; } // Admin, HealthcareProfessional, Patient

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? LastLogin { get; set; }
    }
}
