using System;
using Newtonsoft.Json;
using PJATK.Utils;

namespace PJATK.Models
{
    public class Oplaty
    {
        public double Kwota { get; set; }
        public int LiczbaRat { get; set; }
        public string Nazwa { get; set; }
        public int NrRaty { get; set; }
        [JsonConverter(typeof(CustomDateTimeConverter))]
        public DateTime TerminPlatnosci { get; set; }
    }
}
