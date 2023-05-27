using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;
using System.Threading.Tasks;

namespace WebApplication3.Controllers
{
    [ApiController]
    [Route("api/matches")]
    public class MatchesApiController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public MatchesApiController(DatabaseContext context)
        {
            _context = context;
        }

        // Action method for fetching match data by Id
        [HttpGet("id/{id:int}")]
        public async Task<IActionResult> GetMatchById(int id)
        {
            var match = await _context.Matches.Include(m => m.Odds).SingleOrDefaultAsync(m => m.Id == id);
            return Ok(match);
        }
    }
}