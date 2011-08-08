using nothinbutdotnetprep.utility;

namespace nothinbutdotnetprep.collections
{
    public class IsPublishedBy : IMatchAnItem<Movie>
    {
        ProductionStudio studio;

        public IsPublishedBy(ProductionStudio studio)
        {
            this.studio = studio;
        }

        public bool matches(Movie movie)
        {
            return movie.production_studio == studio;
        }
    }
}