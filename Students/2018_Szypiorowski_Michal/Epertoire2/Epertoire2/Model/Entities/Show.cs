using Newtonsoft.Json;
using System;

namespace Epertoire2.Model.Entities
{
    public class Show
    {
        [JsonProperty("showDate")]
        public DateTimeOffset ShowDate { get; set; }

        [JsonProperty("start")]
        public string Start { get; set; }

        [JsonProperty("is3D")]
        public bool Is3D { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }
    }
}
