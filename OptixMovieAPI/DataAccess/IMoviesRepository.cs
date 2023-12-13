using DataAccess.Models;

namespace DataAccess
{
    public interface IMoviesRepository
    {
        IEnumerable<string> GetGenres();
        IEnumerable<Movie> GetMovies();
        IEnumerable<Movie> GetMoviesByTitle(string? movieTitle, int? resultsSize, int? pageNumber, string? genre);
    }
}