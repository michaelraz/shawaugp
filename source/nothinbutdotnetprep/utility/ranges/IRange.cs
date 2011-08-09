using System;

namespace nothinbutdotnetprep.utility.ranges
{
    public interface IRange<T> where T : IComparable<T>
    {
        bool contains(T item);
    }
}