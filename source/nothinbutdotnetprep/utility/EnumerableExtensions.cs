using System.Collections.Generic;
using nothinbutdotnetprep.utility.filtering;

namespace nothinbutdotnetprep.utility
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> all_items_matching<T>(this IEnumerable<T> items, IMatchAnItem<T> condition)
        {
            return items.all_items_matching(condition.matches);
        }

        public static IEnumerable<T> all_items_matching<T>(this IEnumerable<T> items, Condition<T> condition)
        {
            foreach (var item in items) if (condition(item)) yield return item;
        }

        public static IEnumerable<T> one_at_a_time<T>(this IEnumerable<T> items)
        {
            foreach (var item in items) yield return item;
        }
    }
}