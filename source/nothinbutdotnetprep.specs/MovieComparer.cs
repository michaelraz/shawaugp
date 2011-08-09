using System;
using System.Collections.Generic;
using nothinbutdotnetprep.collections;

namespace nothinbutdotnetprep.specs
{
    public class MovieComparer<PropertyType> : IComparer<Movie>
		where PropertyType : IComparable<PropertyType>
    {
    	private readonly Func<Movie, PropertyType> accessor;

		public MovieComparer(Func<Movie, PropertyType> accessor)
		{
			this.accessor = accessor;
		}

        public int Compare(Movie x, Movie y)
        {
			return accessor(x).CompareTo(accessor(y));
        }
    }
}