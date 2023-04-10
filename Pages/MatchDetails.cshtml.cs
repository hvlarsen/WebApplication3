using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;

namespace WebApplication3.Pages.Matches
{
    public class MatchDetailsModel : PageModel
    {
        private readonly DatabaseContext _context;

        public MatchDetailsModel(DatabaseContext context)
        {
            _context = context;
        }

        [BindProperty(SupportsGet = true)]
        public int? Id { get; set; }

        public Match? Match { get; set; }

        public IActionResult OnGet()
        {
            if (!Id.HasValue)
            {
                return NotFound();
            }

            Match = _context.Matches.Include(m => m.Odds).SingleOrDefault(m => m.Id == Id.Value);

            if (Match == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
