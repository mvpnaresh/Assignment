using Assignment.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.DAL.DataAccess
{
    public interface IMovieDataAccess
    {
        IQueryable<Movie> GetMovies();
    }
}
