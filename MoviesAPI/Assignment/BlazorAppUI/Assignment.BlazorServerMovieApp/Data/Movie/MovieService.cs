using Assignment.BlazorServerMovieApp.Data.RestClients;
using Assignment.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.BlazorServerMovieApp.Data.Movie
{
    public class MovieService : IMovieService
    {
        private readonly IMovieApiManager _movieApiManager;

        public MovieService(IMovieApiManager movieApiManager)
        {
            _movieApiManager = movieApiManager;
        }

        public async Task<IEnumerable<Entity.Movie>> GetMovies()
        {
            return await _movieApiManager.GetMovies();
        }

        public async Task<Entity.Movie> GetMovieById(string imdbId)
        {
            return await _movieApiManager.GetMovieById(imdbId);
        }

        public async Task<IEnumerable<string>> GetLanguages()
        {
            var languages = await _movieApiManager.GetLanguages();
            if (languages != null || languages.Count() > 0)
                return languages.Select(i => i.Language).Distinct().ToList();
            else
                return new List<string>();
        }

        public async Task<IEnumerable<string>> GetLocations()
        {
            var locations = await _movieApiManager.GetLocations();
            if (locations != null || locations.Count() > 0)
                return locations.Select(i => i.Location).Distinct().ToList();
            else
                return new List<string>();
        }
    }
}
