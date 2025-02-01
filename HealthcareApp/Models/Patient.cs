//Define the Database Patient Models

using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;

namespace HealthcareAPI.Models
{
    public class Patient
    {
        [Key]
        public int PatientId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Gender { get; set; }

        public List<Recommendation> Recommendations { get; set; } = new();
    }
}
