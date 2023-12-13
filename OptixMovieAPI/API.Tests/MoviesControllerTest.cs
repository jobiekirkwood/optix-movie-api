using API.Controllers;
using DataAccess;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace API.Tests
{
    public class MoviesControllerTest
    {
        private readonly Mock<IMoviesRepository> _mockMovieRepository;
        private readonly MoviesController _moviesController;

        public MoviesControllerTest()
        {
            _mockMovieRepository = new Mock<IMoviesRepository>();
            _moviesController = new MoviesController(_mockMovieRepository.Object);
        }

        [Fact]
        public void GetMoviesByTitle_ReturnsOkResult_WhenMoviesExist()
        {
            // Arrange
            List<Movie> movies = new List<Movie> { new Movie(), new Movie() };
            _mockMovieRepository.Setup(repo => repo.GetMoviesByTitle(It.IsAny<string>(), It.IsAny<int?>(), It.IsAny<int?>(), It.IsAny<string>())).Returns(movies);

            // Act
            ActionResult<IEnumerable<Movie>> result = _moviesController.GetMoviesByTitle(null, null, null, null, false, false);

            // Assert
            OkObjectResult okResult = Assert.IsType<OkObjectResult>(result.Result);
            List<Movie> returnMovies = Assert.IsType<List<Movie>>(okResult.Value);
            Assert.Equal(2, returnMovies.Count);
        }

        [Fact]
        public void GetMoviesByTitle_NoMovies_ReturnsNoContent()
        {
            // Arrange
            _mockMovieRepository.Setup(repo => repo.GetMoviesByTitle(It.IsAny<string>(), It.IsAny<int?>(), It.IsAny<int?>(), It.IsAny<string>()))
                .Returns(new List<Movie>());

            // Act
            ActionResult<IEnumerable<Movie>> result = _moviesController.GetMoviesByTitle(null, null, null, null, false, false);

            // Assert
            Assert.IsType<NoContentResult>(result.Result);
        }

        [Fact]
        public void GetMoviesByTitle_OrderByDate_ReturnsOrderedMovies()
        {
            // Arrange
            List<Movie> movies =
            [
                new() { Title = "Movie1", ReleaseDate = new DateOnly(2022, 1, 1) },
                new() { Title = "zMovie", ReleaseDate = new DateOnly(2021, 1, 1) },
                new() { Title = "Movie3", ReleaseDate = new DateOnly(2023, 1, 1) }
            ];

            _mockMovieRepository.Setup(repo => repo.GetMoviesByTitle(It.IsAny<string>(), It.IsAny<int?>(), It.IsAny<int?>(), It.IsAny<string>())).Returns(movies);

            // Act
            ActionResult<IEnumerable<Movie>> result = _moviesController.GetMoviesByTitle(null, null, null, null, false, true);

            // Assert
            OkObjectResult okResult = Assert.IsType<OkObjectResult>(result.Result);
            List<Movie> returnedMovies = Assert.IsType<List<Movie>>(okResult.Value);

            Assert.Equal(movies.OrderBy(x => x.ReleaseDate), returnedMovies);
        }

        [Fact]
        public void GetMoviesByTitle_OrderByTitle_ReturnsOrderedMovies()
        {
            // Arrange
            List<Movie> movies =
            [
                new() { Title = "Movie1", ReleaseDate = new DateOnly(2022, 1, 1) },
                new() { Title = "zMovie", ReleaseDate = new DateOnly(2021, 1, 1) },
                new() { Title = "Movie3", ReleaseDate = new DateOnly(2023, 1, 1) }
            ];

            _mockMovieRepository.Setup(repo => repo.GetMoviesByTitle(It.IsAny<string>(), It.IsAny<int?>(), It.IsAny<int?>(), It.IsAny<string>())).Returns(movies);

            // Act
            ActionResult<IEnumerable<Movie>> result = _moviesController.GetMoviesByTitle(null, null, null, null, true, false);

            // Assert
            OkObjectResult okResult = Assert.IsType<OkObjectResult>(result.Result);
            List<Movie> returnedMovies = Assert.IsType<List<Movie>>(okResult.Value);

            Assert.Equal(movies.OrderBy(x => x.Title), returnedMovies);
        }

      
    }
}