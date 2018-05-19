using System.Collections.Generic;

namespace PJATK.Models
{
    public class StudentPersonalData
    {
        public ICollection<Grupy> Grupy { get; set; }
        public string Imie { get; set; }
        public string Konto_wplat { get; set; }
        public string Konto_wyplat { get; set; }
        public double Kwota_naleznosci { get; set; }
        public double Kwota_wplat { get; set; }
        public double Kwota_wyplat { get; set; }
        public string Login { get; set; }
        public string Nazwisko { get; set; }
        public ICollection<Oceny> Oceny { get; set; }
        public ICollection<Oplaty> Oplaty { get; set; }
        public ICollection<Platnosci> Platnosci { get; set; }
        public double Saldo { get; set; }
        public string Status { get; set; }
        public ICollection<Studia> Studia { get; set; }
        public ICollection<object> Wyplaty { get; set; }
        public ICollection<Zajecia> Zajecia { get; set; }
    }
}
