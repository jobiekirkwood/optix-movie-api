using DataAccess;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    [ApiController]
    [Route("[controller]/[action]")]
    public class MoviesController : ControllerBase
    {

        private readonly IMoviesRepository _movieRepository;

        public MoviesController(IMoviesRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        /// <summary>
        /// If nothing is specificied it will return the first 100 results.
        /// </summary>
        /// <param name="movieTitle"></param>
        /// <param name="resultsSize"></param>
        /// <param name="pageNumber"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<IEnumerable<Movie>> GetMoviesByTitle(string? movieTitle, int? resultsSize, int? pageNumber, string? genre, bool orderByTitle, bool orderByDate)
        {
            IEnumerable<Movie> movies = _movieRepository.GetMoviesByTitle(movieTitle, resultsSize, pageNumber, genre);

            if (movies.Count() == 0)
                return NoContent();

            if (orderByDate)
                movies = movies.OrderBy(x => x.ReleaseDate).ToList();

            if (orderByTitle)
                movies = movies.OrderBy(x => x.Title).ToList();

            return Ok(movies);
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> GetGenres()
        {
            IEnumerable<string> genres = _movieRepository.GetGenres();
            return Ok(genres);
        }


    }
}

