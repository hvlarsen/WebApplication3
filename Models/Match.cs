using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication3.Models
{
    public class Match
    {
        [Key] // This attribute marks the property as the primary key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? CountryCode { get; set; }
        public string? EventName { get; set; }
        public DateTime? StartTime { get; set; }
        public List<Odds>? Odds { get; set; }
        public Match() { }
        public Match(string countryCode, string eventname, DateTime startTime, List<Odds> odds)
        {
            this.CountryCode= countryCode;
            this.EventName = eventname;
            this.StartTime = startTime;
            this.Odds = odds;
        }
    }
}