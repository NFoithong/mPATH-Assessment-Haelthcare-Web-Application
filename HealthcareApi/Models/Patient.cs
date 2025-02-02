using System.Collections.Generic;
using System;

namespace HealthcareApi.Models
{
    public class Patient
    {
        public int PatientId { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public ICollection<Recommendation> Recommendations { get; set; }
    }
}
