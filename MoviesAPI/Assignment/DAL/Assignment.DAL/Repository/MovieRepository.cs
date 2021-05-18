using Assignment.DAL.DataAccess;
using Assignment.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.DAL.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private readonly IMovieDataAccess _movieDataAccess;
        public MovieRepository(IMovieDataAccess movieDataAccess)
        {
            _movieDataAccess = movieDataAccess;
        }

        public Movie GetMovie(string imdbId)
        {
            return _movieDataAccess.GetMovies().Where(i => i.ImdbID == imdbId).FirstOrDefault();
        }

        public IEnumerable<Movie> GetMovies()
        {
            return _movieDataAccess.GetMovies();
        }
    }
}
