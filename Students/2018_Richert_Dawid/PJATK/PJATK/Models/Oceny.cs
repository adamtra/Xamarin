using System;
using Newtonsoft.Json;

namespace PJATK.Models
{
    public class Oceny
    {
        public DateTime Data { get; set; }
        public string KodPrzedmiotu { get; set; }
        public int LiczbaGodzin { get; set; }
        public string NazwaPrzedmiotu { get; set; }
        public string NazwaPrzedmiotuAng { get; set; }
        public string Ocena { get; set; }
        public string Prowadzacy { get; set; }
        public string Semestr { get; set; }
        public string Zaliczenie { get; set; }
        public string ZaliczenieAng { get; set; }

        [JsonIgnore]
        public string NazwaKodPrzedmiotu => $"{NazwaPrzedmiotu} ({KodPrzedmiotu})";
    }
}
