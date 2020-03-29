using MarketLab.Domain.Core.Entities;

namespace MarketLab.Domain.SearchLogs.Entities
{
    public class SearchLog : EntityBase
    {
        public int UserId { get; set; }
        public string Keywod { get; set; }
        public int FoundedCount { get; set; }
    }
}