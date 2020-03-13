using System.Linq;
using System.Collections.Generic;
using MarketLab.Application.Core.Extensions.Queries;
using MarketLab.Application.Core.Queries.Primitives;

namespace MarketLab.Application.Core.Extensions
{
    public static class DataQueryExtension
    {
        public static IEnumerable<T> ToDataQueryList<T>(this IEnumerable<T> data, DataQuery query)
        {
            data = data.Search(query.Searching)
                        .Filter(query.Filtering)
                        .Sort(query.Sorting);

            query.Paging.Total = data?.Count() ?? 0;

            return data.ToPagedList(query.Paging);
        }
    }
}