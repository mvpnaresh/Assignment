using Assignment.DAL.DataAccess;
using Assignment.DAL.Repository;
using Assignment.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace Assignment.DAL.Tests
{
    [TestClass]
    public class MovieRepositoryTests
    {
        private Mock<IMovieDataAccess> _mockMovieDataAccess;
        private MovieRepository _movieRepository;

        public MovieRepositoryTests()
        {
            _mockMovieDataAccess = new Mock<IMovieDataAccess>();
            _movieRepository = new MovieRepository(_mockMovieDataAccess.Object);
        }

        [TestMethod]
        public void Get_Movies_Should_Return_Movies()
        {
            //Arrange
            var imdbId = "tt0295297";
            IList<Movie> listMovies = new List<Movie>();
            listMovies.Add(new Movie() { ImdbID = imdbId });
            _mockMovieDataAccess.Setup(x => x.GetMovies()).Returns(listMovies.AsQueryable());
            //Act
            var movies = _movieRepository.GetMovies();
            //Assert
            Assert.IsTrue(movies != null);
            Assert.IsTrue(movies.Count() > 0);
        }

        [TestMethod]
        public void Get_Movie_Should_Return_A_Movie()
        {
            //Arrange
            var imdbId = "tt0295297";
            IList<Movie> listMovies = new List<Movie>();
            listMovies.Add(new Movie() { ImdbID = imdbId });
            _mockMovieDataAccess.Setup(x => x.GetMovies()).Returns(listMovies.AsQueryable());

            //Act
            var movie = _movieRepository.GetMovie(imdbId);
            //Assert
            Assert.IsTrue(movie != null);
        }

        public void Get_Movie_Should_Return_Null_ForIncorrectId()
        {
            //Arrange
            var imdbId = "tt0295297";
            IList<Movie> listMovies = new List<Movie>();
            listMovies.Add(new Movie() { ImdbID = "abcd" });
            _mockMovieDataAccess.Setup(x => x.GetMovies()).Returns(listMovies.AsQueryable());

            //Act
            var movie = _movieRepository.GetMovie(imdbId);
            //Assert
            Assert.IsTrue(movie == null);
        }

    }
}
