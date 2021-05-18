using Assignment.BlazorServerMovieApp.Settings;
using Assignment.Entity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;

namespace Assignment.BlazorServerMovieApp.Data.RestClients
{
    public class MovieApiManager : IMovieApiManager
    {

        private readonly IMovieApiManager _restClient;
        private readonly IOptions<AppSettings> _settings;

        public MovieApiManager(IConfiguration configuration, HttpClient httpClient
            , IOptions<AppSettings> settings)
        {
            _settings = settings;

            string apiHostAndPort = _settings.Value.MoviesApiUrl;
            httpClient.BaseAddress = new Uri($"{apiHostAndPort}");
            _restClient = RestService.For<IMovieApiManager>(httpClient);
        }


        public async Task<Entity.Movie> GetMovieById(string imdbId)
        {
            try
            {
                return await _restClient.GetMovieById(imdbId);
            }
            catch (ApiException ex)
            {
                if (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task<IEnumerable<Entity.Movie>> GetMovies()
        {
            return await _restClient.GetMovies();
        }

        public async Task<IEnumerable<LocationRoot>> GetLocations()
        {
            var returnData = await _restClient.GetLocations();
            return returnData;
        }

        public async Task<IEnumerable<LanguageRoot>> GetLanguages()
        {
            var returnData = await _restClient.GetLanguages();
            return returnData;
        }
    }
}
