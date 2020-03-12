using System.Collections.Generic;
using System.Linq;
using MarketLab.Application.Core.Queries.Primitives;
using MarketLab.Application.Core.Utilities;

namespace MarketLab.Application.Core.Extensions.Queries
{
    public static class SortingQueryExtension
    {
        #region Fileds
        private const string SORT_ASC = "asc";
        private const string SORT_DESC = "desc";
        #endregion
        public static IEnumerable<T> Sort<T>(this IEnumerable<T> objList, SortingQuery sort)
        {
            if (sort == null || sort.Field == null)
                return objList;

            sort.In = sort.In.ToUpperFirstLetter();
            sort.Field = sort.Field.ToUpperFirstLetter();
            sort.Sort = sort.Sort.ToLower();

            if (string.IsNullOrEmpty(sort.In))
            {
                if (sort.Sort == SORT_ASC)
                    objList = objList.OrderBy(q => q.GetType().GetProperty(sort.Field).GetValue(q));

                else if (sort.Sort == SORT_DESC)
                    objList = objList.OrderByDescending(q => q.GetType().GetProperty(sort.Field).GetValue(q));
            }
            else
            {
                var inObj = objList.FirstOrDefault().GetType().GetProperties().FirstOrDefault(q => q.Name == sort.In);
                var inObjField = inObj.GetType().GetProperty(sort.Field);

                if (sort.Sort == SORT_ASC)
                    objList = objList.OrderBy(q => inObj.GetValue(q)?.GetType().GetProperty(sort.Field)?.GetValue(inObj?.GetValue(q)));

                else if (sort.Sort == SORT_DESC)
                    objList = objList.OrderByDescending(q => inObj.GetValue(q)?.GetType().GetProperty(sort.Field)?.GetValue(inObj?.GetValue(q)));
            }

            return objList;
        }
    }
}