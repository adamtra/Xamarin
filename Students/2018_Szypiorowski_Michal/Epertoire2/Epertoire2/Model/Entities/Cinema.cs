using Newtonsoft.Json;
using System.Collections.Generic;

namespace Epertoire2.Model.Entities
{
    public class Cinema
    {
        [JsonProperty("idCinema")]
        public long Id { get; set; }

        [JsonProperty("cinemaName")]
        public string CinemaName { get; set; }

        [JsonProperty("cinemaCity")]
        public string CinemaCity { get; set; }

        [JsonProperty("cinemaType")]
        public int CinemaType { get; set; }

        [JsonProperty("movies")]
        public List<Movie> Movies { get; set; }
    }
}
