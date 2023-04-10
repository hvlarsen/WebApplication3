using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class Odds
    {
        [Key] // This attribute marks the property as the primary key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OddsId { get; set; }
        public DateTime? timeStamp { get; set; }
        public string? teamName { get; set; }
        public double? ltp { get; set; }

        public Odds() { }
        public Odds(DateTime timestamp, string teamName, double ltp)
        {
            this.timeStamp = timestamp;
            this.teamName = teamName;
            this.ltp = ltp;
        }
    }
}
