using Assignment.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.DAL.Repository
{
    public interface IMovieRepository
    {
        Movie GetMovie(string imdbId);
        IEnumerable<Movie> GetMovies();
    }
}
