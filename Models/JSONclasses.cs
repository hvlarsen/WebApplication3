namespace WebApplication3.Models
{
    public class Rootobject
    {
        public int RootobjecktId { get; set; }
        public string? op { get; set; }
        public string? clk { get; set; }
        public long pt { get; set; }
        public ICollection<Mc>? mc { get; set; }
    }

    public class Mc
    {
        public int McId { get; set; }
        public string? id { get; set; }
        public Marketdefinition? marketDefinition { get; set; }
        public ICollection<Rc>? rc { get; set; }
    }

    public class Marketdefinition
    {
        public int MarketdefinitionId { get; set; }
        public bool bspMarket { get; set; }
        public bool turnInPlayEnabled { get; set; }
        public bool persistenceEnabled { get; set; }
        public float marketBaseRate { get; set; }
        public string? eventId { get; set; }
        public string? eventTypeId { get; set; }
        public int numberOfWinners { get; set; }
        public string? bettingType { get; set; }
        public string? marketType { get; set; }
        public DateTime marketTime { get; set; }
        public DateTime suspendTime { get; set; }
        public bool bspReconciled { get; set; }
        public bool complete { get; set; }
        public bool inPlay { get; set; }
        public bool crossMatching { get; set; }
        public bool runnersVoidable { get; set; }
        public int numberOfActiveRunners { get; set; }
        public int betDelay { get; set; }
        public string? status { get; set; }
        public ICollection<Runner>? runners { get; set; }
        // public string[]? regulators { get; set; }
        public string? countryCode { get; set; }
        public bool discountAllowed { get; set; }
        public string? timezone { get; set; }
        public DateTime openDate { get; set; }
        public long version { get; set; }
        public string? name { get; set; }
        public string? eventName { get; set; }
    }

    public class Rc
    {
        public int RcId { get; set; }
        public float ltp { get; set; }
        public int id { get; set; }
    }

    public class Runner
    {
        public int RunnerId { get; set; }
        public string? status { get; set; }
        public int sortPriority { get; set; }
        public int id { get; set; }
        public string? name { get; set; }
    }
}
