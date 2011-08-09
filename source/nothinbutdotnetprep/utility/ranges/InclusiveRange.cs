using System;

namespace nothinbutdotnetprep.utility.ranges
{
    public class InclusiveRange<T> : IRange<T> where T : IComparable<T>
    {
        T start;
        T end;

        public InclusiveRange(T start, T end)
        {
            this.start = start;
            this.end = end;
        }

        public bool contains(T item)
        {
            return item.CompareTo(start) >= 0 && item.CompareTo(end) <= 0;
        }
    }
}