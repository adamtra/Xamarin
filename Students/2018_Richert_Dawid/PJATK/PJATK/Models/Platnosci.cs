using System;
using Newtonsoft.Json;
using PJATK.Utils;

namespace PJATK.Models
{
    public class Platnosci
    {
        [JsonConverter(typeof(CustomDateTimeConverter))]
        public DateTime DataWplaty { get; set; }
        public double Kwota { get; set; }
        public string TytulWplaty { get; set; }
        public string Wplacajacy { get; set; }
    }
}
