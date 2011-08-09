using System;
using nothinbutdotnetprep.utility.ranges;

namespace nothinbutdotnetprep.utility.filtering
{
    public class FallsInRange<T> : IMatchAnItem<T> where T : IComparable<T>
    {
        IRange<T> range;

        public FallsInRange(IRange<T> range)
        {
            this.range = range;
        }

        public bool matches(T item)
        {
            return range.contains(item);
        }
    }
}