using Assignment.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.BlazorServerMovieApp.Data.Movie
{
    interface IMovieService
    {
        Task<IEnumerable<Entity.Movie>> GetMovies();
        Task<Assignment.Entity.Movie> GetMovieById(string imdbId);
        Task<IEnumerable<string>> GetLanguages();
        Task<IEnumerable<string>> GetLocations();
    }
}
