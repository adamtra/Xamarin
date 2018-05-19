using System;

namespace PJATK.Models
{
    public class StudentSchedule
    {
        public string Budynek { get; set; }
        public DateTime Data_roz { get; set; }
        public DateTime Data_zak { get; set; }
        public string Kod { get; set; }
        public string Nazwa { get; set; }
        public string Nazwa_sali { get; set; }
        public string TypZajec { get; set; }
        public int idRealizacja_zajec { get; set; }
    }
}
