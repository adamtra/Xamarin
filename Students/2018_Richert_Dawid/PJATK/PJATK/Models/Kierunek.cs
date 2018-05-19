namespace PJATK.Models
{
    public class Kierunek
    {
        public int IdKierunek { get; set; }
        public int IdWydzial { get; set; }
        public string NazwaKierunek { get; set; }
        public string NazwaKierunekAng { get; set; }
        public string NazwaWydzial { get; set; }
        public string NazwaWydzialAng { get; set; }
        public object Specjalizacja { get; set; }
        public object Studia { get; set; }
    }
}
