using Microsoft.AspNetCore.Mvc;
using HealthBackend.Data;
using HealthBackend.Models;

namespace HealthBackend.Controllers
{
    [Route("api/recommendations")]
    [ApiController]
    public class RecommendationsController : ControllerBase
    {
        private readonly HealthcareDbContext _context;

        public RecommendationsController(HealthcareDbContext context)
        {
            _context = context;
        }

        [HttpGet("{patientId}")]
        public IActionResult GetRecommendations(int patientId)
        {
            var recommendations = _context.Recommendations.Where(r => r.PatientId == patientId).ToList();
            return Ok(recommendations);
        }

        [HttpPut("{id}")]
        public IActionResult MarkAsCompleted(int id)
        {
            var recommendation = _context.Recommendations.Find(id);
            if (recommendation == null) return NotFound();

            recommendation.IsCompleted = true;
            _context.SaveChanges();

            return Ok(recommendation);
        }
    }
}
