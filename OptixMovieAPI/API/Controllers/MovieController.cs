using DataAccess;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
   
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {

        private readonly ILogger<MovieController> _logger;
        private readonly MoviesRepository _movieRepository;

        public MovieController(ILogger<MovieController> logger, MoviesRepository movieRepository)
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
        public ActionResult<IEnumerable<Movie>> Get(string? movieTitle, int? resultsSize, int? pageNumber)
        {
            IEnumerable<Movie> movies = _movieRepository.GetMoviesByTitle(movieTitle, resultsSize, pageNumber);
            return Ok(movies);
        }

       
    }
}

