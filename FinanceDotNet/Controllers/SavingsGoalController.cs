using FinanceDotNet.Data;
using FinanceDotNet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace FinanceDotNet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SavingsGoalsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SavingsGoalsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetSavingsGoals()
        {
            var goals = await _context.SavingsGoals.ToListAsync();
            return Ok(goals);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSavingsGoal(int id)
        {
            var goal = await _context.SavingsGoals.FindAsync(id);
            if (goal == null)
                return NotFound();
            return Ok(goal);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSavingsGoal([FromBody] SavingsGoal goal)
        {
            _context.SavingsGoals.Add(goal);
            await _context.SaveChangesAsync();
            return Ok(goal);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSavingsGoal(int id, [FromBody] SavingsGoal goal)
        {
            if (id != goal.id)
                return BadRequest();

            _context.Entry(goal).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSavingsGoal(int id)
        {
            var goal = await _context.SavingsGoals.FindAsync(id);
            if (goal == null)
                return NotFound();

            _context.SavingsGoals.Remove(goal);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}

