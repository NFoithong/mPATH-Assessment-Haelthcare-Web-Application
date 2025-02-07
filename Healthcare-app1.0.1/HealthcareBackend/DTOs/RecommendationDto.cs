namespace HealthcareBackend.DTOs
{
    public class RecommendationDto
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public bool IsCompleted { get; set; }
        public int PatientId { get; set; }
    }
}
