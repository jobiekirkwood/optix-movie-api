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
        private readonly AppDbContext _appDbContext;

        public MovieController(ILogger<MovieController> logger, AppDbContext appDbContext)
        {
            _logger = logger;
            _appDbContext = appDbContext;
        }

        [HttpGet(Name = "GetMovieByTitle")]
        public ActionResult<IEnumerable<Movie>> Get(string title)
        {
            if (string.IsNullOrEmpty(title))
            {
                return NoContent();
            }
            else
            {
                return new List<Movie>() { new Movie { Title = "onemovie" }, new Movie { Title = "twoMovie" } };
                return _appDbContext.Movies.Where(x => x.Title.Contains(title)).ToList();
            }





            return Ok(new { title });
        }
    }
}
