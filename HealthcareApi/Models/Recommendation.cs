namespace HealthcareApi.Models
{
    public class Recommendation
    {
        public int RecommendationId { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
    }
}
