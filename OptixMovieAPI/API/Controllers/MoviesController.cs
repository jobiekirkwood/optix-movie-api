using DataAccess;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    [ApiController]
    [Route("[controller]/[action]")]
    public class MoviesController : ControllerBase
    {

        private readonly ILogger<MoviesController> _logger;
        private readonly MoviesRepository _movieRepository;

        public MoviesController(ILogger<MoviesController> logger, MoviesRepository movieRepository)
        {
            _logger = logger;
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

            if (orderByDate)
                movies = movies.OrderBy(x => x.ReleaseDate);

            if (orderByTitle)
                movies = movies.OrderBy(x => x.Title);

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

