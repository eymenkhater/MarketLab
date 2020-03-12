using System.Collections.Generic;

namespace MarketLab.Application.Core.Queries.Primitives
{
    public class DataQuery
    {
        public PagingQuery Paging { get; set; }
        public List<SearchingQuery> Searching { get; set; }
        public List<FilteringQuery> Filtering { get; set; }
        public SortingQuery Sorting { get; set; }
    }
}