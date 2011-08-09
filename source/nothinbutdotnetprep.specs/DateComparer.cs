using System.Collections.Generic;
using nothinbutdotnetprep.collections;

namespace nothinbutdotnetprep.specs
{
    public class DateComparer : IComparer<Movie>
    {
        public int Compare(Movie x, Movie y)
        {
            return x.date_published.CompareTo(y.date_published);
        }
    }
}