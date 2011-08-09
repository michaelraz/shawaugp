using System.Collections.Generic;

namespace nothinbutdotnetprep.utility.sorting
{
    public class FixedComparer<T> : IComparer<T>
    {
        IList<T> values;

        public FixedComparer(params T[] values)
        {
            this.values = new List<T>(values);
        }

        public int Compare(T x, T y)
        {
            return values.IndexOf(x).CompareTo(values.IndexOf(y));
        }
    }
}