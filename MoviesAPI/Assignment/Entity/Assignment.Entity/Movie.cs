using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Assignment.Entity
{
    
    public class Movie
    {
        public string Location { get; set; }
        public string Language { get; set; }
        public string Plot { get; set; }
        public string Poster { get; set; }
        public List<string> SoundEffects { get; set; }
        public List<string> Stills { get; set; }
        public string Title { get; set; }
        [Key]
        [JsonPropertyName("imdbID")]
        public string ImdbID { get; set; }
        [JsonPropertyName("listingType")]
        public string ListingType { get; set; }
        [JsonPropertyName("imdbRating")]
        public string ImdbRating { get; set; }
    }
}
