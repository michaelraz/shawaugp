using nothinbutdotnetprep.utility;

namespace nothinbutdotnetprep.collections
{
    public class MovieMatch : IMatchAnItem<Movie>
    {
    	readonly Condition<Movie> condition;

		public MovieMatch(Condition<Movie> condition)
		{
			this.condition = condition;
		}

        public bool matches(Movie movie)
        {
        	return condition(movie);
        } 
    }
}