using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;

namespace WebApplication3.Pages
{
    public class IndexModel : PageModel
    {
        private readonly DatabaseContext _context;

        public IndexModel(DatabaseContext context)
        {
            _context = context;
        }
        public int? Id { get; set; }

        public Match? Match { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
            int maxId = await _context.Matches.MaxAsync(m => m.Id);
            Match = await _context.Matches.Include(m => m.Odds).SingleOrDefaultAsync(m => m.Id == maxId);
            return Page();
        }
    }
}