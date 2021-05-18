using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Assignment.Entity
{
    public class MovieDocument
    {
        [JsonPropertyName("movies")]
        public IEnumerable<Movie> Movies { get; set; }
    }
}
