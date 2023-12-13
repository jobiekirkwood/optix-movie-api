using DataAccess.Models;
using System.Reflection.Metadata.Ecma335;

namespace DataAccess
{
    public class MoviesRepository : IMoviesRepository
    {
        private readonly AppDbContext _appDbContext;

        public MoviesRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Movie> GetMovies()
        {
            return _appDbContext.Movies;
        }

        public IEnumerable<Movie> GetMoviesByTitle(string? movieTitle, int? resultsSize, int? pageNumber, string? genre)
        {
            movieTitle ??= "";
            genre ??= "";

            IEnumerable<Movie> movies = GetMovies()
                                                    .Where(x => x.Title.Contains(movieTitle))
                                                    .Where(x => x.Genre.Contains(genre))
                                                    .OrderBy(x => x.Id);

            if (resultsSize is null)
            {
                if (pageNumber is null)  //no size no page specified then send back eveything  
                    return movies.Take(100);
                else
                    resultsSize = 20;   //no size, set a default result size for a different page
            }


            pageNumber ??= 1;           // size but no page? then its from the first page

            int resultsToSkip = ((int)pageNumber - 1) * (int)resultsSize;

            return movies.Skip(resultsToSkip).Take((int)resultsSize);



        }

        public IEnumerable<string> GetGenres()
        {
            return _appDbContext.Movies.Select(x => x.Genre).Distinct().OrderBy(x => x);
        }

    }
}
