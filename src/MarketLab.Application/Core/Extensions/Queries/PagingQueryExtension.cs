using System.Collections.Generic;
using System.Linq;
using MarketLab.Application.Core.Queries.Primitives;

namespace MarketLab.Application.Core.Extensions.Queries
{
    public static class PagingQueryExtension
    {
        public static IEnumerable<T> ToPagedList<T>(this IEnumerable<T> objList, PagingQuery paging)
        {
            if ((objList == null || objList.Count() == 0) || (paging == null))
                return objList;
            else
                return objList.Skip((paging.Page - 1) * paging.ItemsPerPage).Take(paging.ItemsPerPage);
        }
    }
}