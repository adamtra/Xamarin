using Epertoire2.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace Epertoire2.ViewModels
{
    public class CinemaViewModel : ViewModel
    {
        private readonly IDataStorage _dataStorage;

        public Pin Pin { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Street { get; set; }
        public string Post { get; set; }

        public CinemaViewModel(IDataStorage dataStorage, string cinemaName)
        {
            _dataStorage = dataStorage;
            Name = cinemaName;
            Refresh();
        }

        public CinemaViewModel(string cinemaName) : this(DependencyService.Get<IDataStorage>(), cinemaName)
        {

        }

        public void Refresh()
        {
            var cinema = Task.Run(() => _dataStorage.GetCinema(Name)).Result;
            var position = new Position(cinema.Latitude, cinema.Longtitude);
            Pin = new Pin
            {
                Label = Name,
                Position = position
            };

            Email = cinema.Email;
            Phone = cinema.Phone;
            Street = cinema.Street + " " + cinema.Number;
            Post = cinema.PostalCode + " " + cinema.City;
        }
    }
}
