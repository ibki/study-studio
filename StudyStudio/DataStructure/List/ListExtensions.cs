
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructure.List
{
    public static class ListExtensions
    {
        public static bool IsEmpty<T>(this IList<T> list) => !list.Any();

        public static bool TryFindFirst<T>(this IList<T> list, Predicate<T> match, out T found)
        {
            found = default(T);

            if (list?.Any() == false)
                return false;

            foreach (var i in list)
            {
                if (match(i))
                {
                    found = i;
                    return true;
                }
            }

            return false;
        }

        public static void Swap<T>(this IList<T> list, int firstIndex, int secondIndex)
        {
            if (list.Count < 2 || firstIndex == secondIndex)
                return;

            var temp = list[firstIndex];
            list[firstIndex] = list[secondIndex];
            list[secondIndex] = temp;
        }
    }
}
