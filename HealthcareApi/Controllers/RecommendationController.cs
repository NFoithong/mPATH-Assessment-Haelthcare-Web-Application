using Microsoft.AspNetCore.Mvc;
using HealthcareAPI.Data;
using HealthcareAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace HealthcareAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecommendationController : ControllerBase
    {
        private readonly HealthcareContext _context;

        public RecommendationController(HealthcareContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Recommendation>> AddRecommendation(Recommendation recommendation)
        {
            _context.Recommendations.Add(recommendation);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetRecommendation), new { id = recommendation.RecommendationId }, recommendation);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Recommendation>> GetRecommendation(int id)
        {
            var recommendation = await _context.Recommendations.FindAsync(id);
            if (recommendation == null) return NotFound();
            return recommendation;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRecommendation(int id, Recommendation recommendation)
        {
            if (id != recommendation.RecommendationId) return BadRequest();
            _context.Entry(recommendation).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
