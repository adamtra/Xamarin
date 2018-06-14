using Newtonsoft.Json;

namespace Epertoire2.Model.Entities
{
    public class Rating
    {
        [JsonProperty("id_Cinema")]
        public long CinemaId { get; set; }

        [JsonProperty("id_Movie")]
        public long MovieId { get; set; }

        [JsonProperty("id_User")]
        public long UserId { get; set; }

        [JsonProperty("id_StringUser")]
        public string UserStringId { get; set; }

        [JsonProperty("cleanliness")]
        public double Cleanliness { get; set; }

        [JsonProperty("screen")]
        public double Screen { get; set; }

        [JsonProperty("seat")]
        public double Comfort { get; set; }

        [JsonProperty("popcorn")]
        public double Snacks { get; set; }

        [JsonProperty("sound")]
        public double Sound { get; set; }
    }
}
