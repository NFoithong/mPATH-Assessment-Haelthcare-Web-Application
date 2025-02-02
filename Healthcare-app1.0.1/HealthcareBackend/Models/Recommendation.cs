namespace HealthcareBackend.Models
{
    public class Recommendation
    {
        public int Id { get; set; }
        public string Type { get; set; } // Allergy check, Screening, Follow-up
        public bool IsCompleted { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
    }
}
