using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment.Entity;

namespace Assignment.BlazorServerMovieApp.Data.RestClients
{
    public interface IMovieApiManager
    {
        [Get("")]
        Task<IEnumerable<Entity.Movie>> GetMovies();

        [Get("/{imdbId}")]
        Task<Assignment.Entity.Movie> GetMovieById(string imdbId);

        [Get("/?$select=Location")]
        Task<IEnumerable<LocationRoot>> GetLocations();

        [Get("/?select=Language")]
        Task<IEnumerable<LanguageRoot>> GetLanguages();
    }
}
