using DataAccess.Models;
using System.Reflection.Metadata.Ecma335;

namespace DataAccess
{
    public class MoviesRepository
    {
        private readonly AppDbContext _appDbContext;

        public MoviesRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Movie> GetMoviesByTitle(string? movieTitle, int? resultsSize, int? pageNumber)
        {
            movieTitle ??= "";
            IEnumerable<Movie> movies = _appDbContext.Movies.Where(x => x.Title.Contains(movieTitle)).OrderBy(x=>x.Id);

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


    }
}
