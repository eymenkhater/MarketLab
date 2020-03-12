using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MarketLab.Application.Core.Queries;
using MarketLab.Application.Core.Utilities;

namespace MarketLab.Application.Core.Extensions.Queries
{
    public static class FilteringQueryExtension
    {
        public static IEnumerable<T> Filter<T>(this IEnumerable<T> objList, IEnumerable<FilteringQuery> query)
        {
            if (objList == null || objList.Count() == 0 || query == null || !query.Any())
                return objList;


            var filteredObjectData = new List<T>();

            foreach (var myItemObject in objList)
            {
                var matches = new List<bool>();

                foreach (var item in query)
                {
                    bool isMatch = string.IsNullOrEmpty(item.In)
                                    ? DetectObjectIsEqual(item, myItemObject)
                                    : DetectInNestedObjectIsEqual(item, myItemObject);

                    matches.Add(isMatch);
                }

                if (matches.Any(x => x))
                    filteredObjectData.Add(myItemObject);
            }

            return filteredObjectData;
        }
        private static bool DetectObjectIsEqual<T>(FilteringQuery query, T src)
        {
            bool isMatch = false;

            foreach (var itemObject in src.GetType().GetProperties())
            {
                if (query.Field.ToLower() != itemObject.Name.ToLower())
                    continue;

                var objectValue = itemObject.GetValue(src);
                isMatch = objectValue != null && objectValue.ToString().ToLower() == query.Value.ToLower();

                break;
            }

            return isMatch;
        }
        private static bool DetectInNestedObjectIsEqual<T>(FilteringQuery query, T src)
        {
            query.In = query.In.ToUpperFirstLetter();

            var objIn = ReflectionExtension.GetPropertyValue(src, query.In);

            if (objIn == null)
                return default;

            var inQuery = new FilteringQuery() { Field = query.Field, Value = query.Value };

            if (!(objIn is IEnumerable))
                return DetectObjectIsEqual(inQuery, objIn);

            return default;
        }

    }
}