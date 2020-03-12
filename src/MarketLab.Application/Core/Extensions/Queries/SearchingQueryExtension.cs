using System.Linq;
using System.Collections.Generic;
using MarketLab.Application.Core.Queries.Primitives;
using MarketLab.Application.Core.Utilities;
using System.Collections;

namespace MarketLab.Application.Core.Extensions.Queries
{
    public static class SearchingQueryExtension
    {
        public static IEnumerable<T> Search<T>(this IEnumerable<T> objList, string keyword, string[] includedObjectNames = null, string[] ignoredObjectNames = null)
        {
            if (objList == null || objList.Count() == 0 || string.IsNullOrEmpty(keyword))
                return objList;

            var myObject = objList.First();

            var filteredPropertyNames = new List<string>();

            foreach (var itemObject in myObject.GetType().GetProperties())
            {
                if (itemObject.PropertyType != typeof(string))
                    continue;

                if (includedObjectNames != null && includedObjectNames.Count() > 0 && includedObjectNames.Contains(itemObject.Name))
                    filteredPropertyNames.Add(itemObject.Name);
                else if (ignoredObjectNames != null && ignoredObjectNames.Count() > 0 && !includedObjectNames.Contains(itemObject.Name))
                    filteredPropertyNames.Add(itemObject.Name);
                else
                    filteredPropertyNames.Add(itemObject.Name);
            }

            var filteredObjectData = new List<T>();

            foreach (var myItemObject in objList)
            {
                foreach (var itemObject in myItemObject.GetType().GetProperties())
                {
                    var objectValue = itemObject.GetValue(myItemObject);

                    if (filteredPropertyNames.Contains(itemObject.Name) && objectValue != null && objectValue.ToString().ToLower().Contains(keyword.ToLower()))
                    {
                        filteredObjectData.Add(myItemObject);
                        break;
                    }
                }
            }

            return filteredObjectData;
        }
        public static IEnumerable<T> Search<T>(this IEnumerable<T> objList, IEnumerable<SearchingQuery> queries)
        {
            if (objList == null || objList.Count() == 0 || queries == null || !queries.Any())
                return objList;


            var filteredObjectData = new List<T>();

            foreach (var myItemObject in objList)
            {
                var matches = new List<bool>();

                foreach (var item in queries)
                {
                    bool isMatch = string.IsNullOrEmpty(item.In)
                                    ? DetectObjectIsContains(item, myItemObject)
                                    : DetectInNestedObjectIsContains(item, myItemObject);

                    matches.Add(isMatch);
                }

                if (matches.Any(x => x))
                    filteredObjectData.Add(myItemObject);
            }

            return filteredObjectData;
        }

        #region Private Methods
        private static bool DetectObjectIsContains<T>(SearchingQuery query, T src)
        {
            bool isMatch = false;

            foreach (var itemObject in src.GetType().GetProperties())
            {
                if (query.Field.ToLower() != itemObject.Name.ToLower())
                    continue;

                var objectValue = itemObject.GetValue(src);
                isMatch = objectValue != null && objectValue.ToString().ToLower().Contains(query.Keyword.ToLower());

                break;
            }
            return isMatch;
        }
        private static bool DetectInNestedObjectIsContains<T>(SearchingQuery query, T src)
        {
            query.In = query.In.ToUpperFirstLetter();

            var objIn = ReflectionExtension.GetPropertyValue(src, query.In);
            var inQuery = new SearchingQuery() { Field = query.Field, Keyword = query.Keyword };

            if (objIn == null)
                return default;

            if (!(objIn is IEnumerable))
                return DetectObjectIsContains(inQuery, objIn);

            return false;
        }
        #endregion
    }
}