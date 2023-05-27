using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;

namespace WebApplication3.Pages.Matches
{
    public class DKmatchesModel : PageModel
    {
        private readonly DatabaseContext _context;

        public DKmatchesModel(DatabaseContext context)
        {
            _context = context;
            MatchesByDate = new Dictionary<DateTime, List<Match>>();
        }

        public Dictionary<DateTime, List<Match>> MatchesByDate { get; set; }

        public async Task OnGetAsync()
        {
            var matches = await _context.Matches.ToListAsync();
            MatchesByDate = matches
                .Where(m => m.CountryCode == "DK")
                .GroupBy(m => m.StartTime?.Date ?? DateTime.MinValue)
                .OrderByDescending(g => g.Key)
                .ToDictionary(g => g.Key, g => g.ToList());
        }
    }
}