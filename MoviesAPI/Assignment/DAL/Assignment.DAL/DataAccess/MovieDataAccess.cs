using Assignment.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Assignment.DAL.DataAccess
{
    public class MovieDataAccess : IMovieDataAccess
    {
        private MovieDocument _movieDocument;

        public MovieDataAccess()
        {
            ReadJsonFile();
        }

        private void ReadJsonFile()
        {
            var outputPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            var file = Path.Combine(outputPath, "JsonDocument", "movies.json");
            var jsonData = System.IO.File.ReadAllText(file);
            _movieDocument = JsonSerializer.Deserialize<MovieDocument>(jsonData);
            
        }

        public IQueryable<Movie> GetMovies()
        {
            return _movieDocument.Movies.AsQueryable();
        }
    }
}
