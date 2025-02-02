using System.Collections.Generic;

namespace HealthcareBackend.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MedicalRecordNumber { get; set; }
        public List<Recommendation> Recommendations { get; set; }
    }
}
