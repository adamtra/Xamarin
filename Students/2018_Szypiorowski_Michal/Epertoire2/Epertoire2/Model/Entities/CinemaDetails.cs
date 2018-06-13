using Newtonsoft.Json;

namespace Epertoire2.Model.Entities
{
    public class CinemaDetails
    {
        [JsonProperty("id_Self")]
        public long InternalId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("cinemaType")]
        public long CinemaType { get; set; }

        [JsonProperty("street")]
        public string Street { get; set; }

        [JsonProperty("number")]
        public string Number { get; set; }

        [JsonProperty("postalCode")]
        public string PostalCode { get; set; }

        [JsonProperty("longtitude")]
        public double Longtitude { get; set; }

        [JsonProperty("latitude")]
        public double Latitude { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }
    }
}
