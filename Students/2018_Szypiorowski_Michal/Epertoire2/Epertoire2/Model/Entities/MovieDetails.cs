using Newtonsoft.Json;

namespace Epertoire2.Model.Entities
{
    public class MovieDetails
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("id_Movie")]
        public string MovieId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("original_Name")]
        public string OriginalName { get; set; }

        [JsonProperty("length")]
        public long Length { get; set; }

        [JsonProperty("director")]
        public string Director { get; set; }

        [JsonProperty("writers")]
        public string Writers { get; set; }

        [JsonProperty("stars")]
        public string Cast { get; set; }

        [JsonProperty("storyline")]
        public string Storyline { get; set; }

        [JsonProperty("trailer")]
        public string Trailer { get; set; }

        [JsonProperty("music")]
        public string Music { get; set; }

        [JsonProperty("cinematography")]
        public string Cinematography { get; set; }

        [JsonProperty("rating")]
        public string Rating { get; set; }

        [JsonProperty("shows")]
        public object Shows { get; set; }

        [JsonProperty("genre")]
        public object Genre { get; set; }
    }
}
