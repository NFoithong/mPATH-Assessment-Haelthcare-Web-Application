using Microsoft.EntityFrameworkCore;
using HealthcareApi.Models;
using System.Collections.Generic;
using System;

namespace HealthcareApi.Data
{
    public static class DataSeeder
    {
        public static void Seed(HealthcareContext context)
        {
            if (!context.Patients.Any())
            {
                var patients = new List<Patient>
                {
                    new Patient { Name = "John Doe", DateOfBirth = DateTime.Parse("1980-01-01") },
                    new Patient { Name = "Jane Smith", DateOfBirth = DateTime.Parse("1990-02-20") }
                };
                context.Patients.AddRange(patients);
                context.SaveChanges();
            }
        }
    }
}
