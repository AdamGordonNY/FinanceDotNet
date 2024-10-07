using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FinanceDotNet.Models;
using FinanceDotNet.Data;

namespace FinanceDotNet.Controllers
{

        [ApiController]
        [Route("api/[controller]")]
    [Produces("application/json")]
        public class TransactionController : ControllerBase
        {
            private readonly ApplicationDbContext _context;
            public TransactionController(ApplicationDbContext context)
            {
                _context = context;
            }
        /// <summary>
        /// Gets all transactions.
        /// </summary>
        /// <returns>A list of transactions</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetTransactions()
            {
                var transactions = await _context.Transactions.Include(t => t.Category).ToListAsync();
                return Ok(transactions);

            }
        /// <summary>
        /// Gets a transaction by ID.
        /// </summary>
        /// <param name="id">The ID of the transaction</param>
        /// <returns>A single transaction</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetTransaction(int id)
            {
                var transaction = await _context.Transactions.Include(t => t.Category).FirstOrDefaultAsync(t => t.Id == id);
                if (transaction == null)
                {
                    return NotFound();
                }
                return Ok(transaction);
            }
            [HttpPost]
            public async Task<IActionResult> CreateTransaction([FromBody] Transaction transaction)
            {
                _context.Transactions.Add(transaction);
                await _context.SaveChangesAsync();
                return Ok(transaction);
            }

            [HttpPut("{id}")]
            public async Task<IActionResult> UpdateTransaction(int id, [FromBody] Transaction transaction)
            {
                if (id != transaction.Id)
                    return BadRequest();

                _context.Entry(transaction).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return NoContent();
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteTransaction(int id)
            {
                var transaction = await _context.Transactions.FindAsync(id);
                if (transaction == null)
                    return NotFound();

                _context.Transactions.Remove(transaction);
                await _context.SaveChangesAsync();
                return NoContent();
            }
        }
    }
    
