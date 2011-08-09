using System.Collections.Generic;

namespace nothinbutdotnetprep.utility.filtering
{
    public class IsEqualToAny<T> : IMatchAnItem<T>
    {
        IList<T> values;

        public IsEqualToAny(params T[] values)
        {
            this.values = new List<T>(values);
        }

        public bool matches(T item)
        {
            return values.Contains(item);
        }
    }
}