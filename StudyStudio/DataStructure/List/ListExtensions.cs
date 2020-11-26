
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructure.List
{
    public static class ListExtensions
    {
        public static bool TryFindFirst<T>(this List<T> list, Predicate<T> match, out T found)
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
    }
}
