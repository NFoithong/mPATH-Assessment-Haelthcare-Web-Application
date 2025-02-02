using Microsoft.AspNetCore.Mvc;
using HealthBackend.Data;
using HealthBackend.Models;
using System.Threading.Tasks;

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
        [HttpPost("{id}/complete")]
        public async Task<IActionResult> CompleteRecommendation(int id)
        {
            var recommendation = await _context.Recommendations.FindAsync(id);
            if (recommendation == null) return NotFound();

            recommendation.IsCompleted = true;
            await _context.SaveChangesAsync();

            return Ok(new { message = "Recommendation marked as completed" });
        }

    }
}
