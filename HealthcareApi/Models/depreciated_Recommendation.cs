//Define the Database Recommendation Models


using System.ComponentModel.DataAnnotations;

namespace HealthcareAPI.Models
{
    public class Recommendation
    {
        [Key]
        public int RecommendationId { get; set; }

        [Required]
        public string Type { get; set; } // Allergy Check, Screening

        public string Description { get; set; }

        public bool IsCompleted { get; set; } = false;

        public int PatientId { get; set; }

        public Patient Patient { get; set; }
    }
}
