using Microsoft.EntityFrameworkCore;

namespace WebApplication3.Models
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Match> Matches { get; set; }
        public DbSet<Odds> Odds { get; set; }
        public string? DbPath { get; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
    => options.UseSqlite(@"Data Source=BetfairWebApp.db;");

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }
    }
}