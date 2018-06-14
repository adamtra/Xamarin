using Newtonsoft.Json;
using System.Collections.Generic;

namespace Epertoire2.Model.Entities
{
    public class Movie
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("movieName")]
        public string Title { get; set; }

        [JsonProperty("showList")]
        public List<Show> Shows { get; set; }

        [JsonProperty("genres")]
        public List<string> Genres { get; set; }

        [JsonProperty("averageRating")]
        public double Rating { get; set; }
    }
}
