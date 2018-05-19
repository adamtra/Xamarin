using System.Collections.Generic;
using PJATK.Models;

namespace PJATK.DataModels
{
    public class PaymentsDataModel
    {
        public string Konto_wplat { get; set; }
        public string Konto_wyplat { get; set; }
        public double Kwota_naleznosci { get; set; }
        public double Kwota_wplat { get; set; }
        public double Kwota_wyplat { get; set; }
        public double Saldo { get; set; }
        public ICollection<Oplaty> Oplaty { get; set; }
        public ICollection<Platnosci> Platnosci { get; set; }
    }
}
