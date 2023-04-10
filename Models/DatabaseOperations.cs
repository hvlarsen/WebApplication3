using Microsoft.EntityFrameworkCore;

namespace WebApplication3.Models
{
    public class DatabaseOperations
    {
        private readonly DatabaseContext _context;

        public DatabaseOperations(DatabaseContext context)
        {
            _context = context;
        }

        public async Task AddToDbAsync(Match match)
        {
            await _context.AddAsync(match);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAllDataAsync()
        {
            await _context.Database.ExecuteSqlRawAsync("DELETE FROM Odds");
            await _context.Database.ExecuteSqlRawAsync("DELETE FROM Matches");
        }
    }
}

