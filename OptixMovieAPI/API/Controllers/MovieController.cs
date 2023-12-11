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
       

        public MovieController(ILogger<MovieController> logger)
        {
            _logger = logger;
            
        }

        [HttpGet(Name = "GetMovieByTitle")]
        public ActionResult<IEnumerable<Movie>> Get(string title)
        {
         
           
                return new List<Movie>() { new Movie { Title = "onemovie" }, new Movie { Title = "twoMovie" } };
                //return _appDbContext.Movies.Where(x => x.Title.Contains(title)).ToList();
           





            return Ok(new { title });
        }
    }
}
