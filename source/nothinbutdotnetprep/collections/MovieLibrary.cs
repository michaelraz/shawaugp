using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.collections
{
    public class MovieLibrary
    {
        IList<Movie> movies;

        public MovieLibrary(IList<Movie> list_of_movies)
        {
            this.movies = list_of_movies;
        }

        public IEnumerable<Movie> all_movies()
        {
            return this.movies;
        }

        public void add(Movie movie)
        {
            if (already_contains(movie)) return;

            movies.Add(movie);
        }

        bool already_contains(Movie movie)
        {
            foreach (var tmpMovie in movies)
            {
                if (tmpMovie.title == movie.title)
                    return true;
            }
            return false;
        }

        public IEnumerable<Movie> sort_all_movies_by_title_descending()
        {
            foreach (var movie in movies)
            {
            }
            throw new NotImplementedException();
        }

        public IEnumerable<Movie> all_movies_published_by_pixar()
        {
            var list = new List<Movie>();
            foreach (var movie in movies)
            {
                if (movie.production_studio == ProductionStudio.Pixar)
                    list.Add(movie);
            }
            return list;
        }

        public IEnumerable<Movie> all_movies_published_by_pixar_or_disney()
        {
            var list = new List<Movie>();
            foreach (var movie in movies)
            {
                if (movie.production_studio == ProductionStudio.Pixar ||
                    movie.production_studio == ProductionStudio.Disney)
                    list.Add(movie);
            }
            return list;
        }

        public IEnumerable<Movie> sort_all_movies_by_title_ascending()
        {
            foreach (var movie in movies)
            {
            }
            throw new NotImplementedException();
        }

        public IEnumerable<Movie> sort_all_movies_by_movie_studio_and_year_published()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Movie> all_movies_not_published_by_pixar()
        {
            var list = new List<Movie>();
            foreach (var movie in movies)
            {
                if (movie.production_studio != ProductionStudio.Pixar)
                    list.Add(movie);
            }
            return list;
        }

        public IEnumerable<Movie> all_movies_published_after(int year)
        {
            var list = new List<Movie>();
            foreach (var movie in movies)
            {
                if (movie.date_published.Year > year)
                    list.Add(movie);
            }
            return list;
        }

        public IEnumerable<Movie> all_movies_published_between_years(int startingYear, int endingYear)
        {
            var list = new List<Movie>();
            foreach (var movie in movies)
            {
                if (movie.date_published.Year >= startingYear && movie.date_published.Year <= endingYear)
                    list.Add(movie);
            }
            return list;
        }

        public IEnumerable<Movie> all_kid_movies()
        {
            var list = new List<Movie>();
            foreach (var movie in movies)
            {
                if (movie.genre == Genre.kids)
                    list.Add(movie);
            }
            return list;
        }

        public IEnumerable<Movie> all_action_movies()
        {
            var list = new List<Movie>();
            foreach (var movie in movies)
            {
                if (movie.genre == Genre.action)
                    list.Add(movie);
            }
            return list;
        }

        public IEnumerable<Movie> sort_all_movies_by_date_published_descending()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Movie> sort_all_movies_by_date_published_ascending()
        {
            throw new NotImplementedException();
        }
    }
}