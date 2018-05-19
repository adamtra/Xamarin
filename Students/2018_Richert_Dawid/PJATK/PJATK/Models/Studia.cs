using System.Collections.Generic;

namespace PJATK.Models
{
    public class Studia
    {
        public int IdWpisNaSemestr { get; set; }
        public Kierunek Kierunek { get; set; }
        public string Nazwa { get; set; }
        public ICollection<Oceny> Oceny { get; set; }
        public int RokStudiow { get; set; }
        public int SemestrStudiow { get; set; }
        public string Specjalizacja { get; set; }
        public double SredniaRok { get; set; }
        public double SredniaSem { get; set; }
        public double SredniaStudia { get; set; }
    }
}
