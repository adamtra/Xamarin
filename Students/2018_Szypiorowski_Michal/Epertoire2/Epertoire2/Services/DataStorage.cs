using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Epertoire2.Model.Entities;
using Epertoire2.Model.Entities.Converters;
using Epertoire2.Resources;
using Xamarin.Forms;

[assembly: Dependency(typeof(Epertoire2.Services.DataStorage))]
namespace Epertoire2.Services
{
    public class DataStorage : IDataStorage
    {
        private readonly ICacheService _cacheService;
        private readonly IConnectivity _connectivity;
        private readonly IHttpService _httpService;
        private readonly IJsonConverter _jsonConverter;
        private readonly INotificationManager _notificationManager;

        public DataStorage(ICacheService cacheService, IConnectivity connectivity, IHttpService httpService,
            IJsonConverter jsonConverter, INotificationManager notificationManager)
        {
            _cacheService = cacheService;
            _connectivity = connectivity;
            _httpService = httpService;
            _jsonConverter = jsonConverter;
            _notificationManager = notificationManager;
        }

        public DataStorage() : 
            this(DependencyService.Get<ICacheService>(), DependencyService.Get<IConnectivity>(), DependencyService.Get<IHttpService>(),
                DependencyService.Get<IJsonConverter>(), DependencyService.Get<INotificationManager>())
        {

        }

        private DateTimeOffset CacheExpiry(double minutes)
        {
            return new DateTimeOffset(DateTime.Now.AddMinutes(minutes));
        }

        private void ShowConnectionNotification()
        {
            _notificationManager.CreateToastNotifier("You're not connected.", "Make sure, that your Internet connection is on, then try again", 50);
        }

        private void ShowGetFailedNotification()
        {
            _notificationManager.CreateToastNotifier("We experienced an error" , "We couldn't get requested repertoire's details. Try again later.", 50);
        }

        public async Task<CinemaDetails> GetCinema(string name)
        {
            CinemaDetails cinema = _cacheService.Get<CinemaDetails>(name);

            if (cinema == null)
            {
                if (_connectivity.EnsureInternetAccess())
                {
                    var uri = ResourceIdentifier.CinemasUri();
                    try
                    {
                        var responseString = await _httpService.Get(uri);
                        var cinemas = (List<CinemaDetails>)_jsonConverter.DeserializeObject(responseString, typeof(List<CinemaDetails>));
                        var query = (from c in cinemas where (c.Name + " " + c.City).Equals(name) select c);
                        cinema = query.First();
                        _cacheService.Set(name, cinema, CacheExpiry(15.0));
                    }
                    catch
                    {
                        ShowGetFailedNotification();
                        return new CinemaDetails();
                    }
                }
                else
                {
                    ShowConnectionNotification();
                    return new CinemaDetails();
                }
            }

            return cinema;
        }

        public async Task<ObservableCollection<Cinema>> GetCinemaRepertoires(string city)
        {
            ObservableCollection<Cinema> cinemas = _cacheService.Get<ObservableCollection<Cinema>>(city);

            if (cinemas == null || cinemas.Count == 0)
            {
                if (_connectivity.EnsureInternetAccess())
                {
                    var uri = ResourceIdentifier.CinemaRepertoiresUri(city);
                    try
                    {
                        var responseString = await _httpService.Get(uri);
                        cinemas = new ObservableCollection<Cinema>((List<Cinema>)_jsonConverter.DeserializeObject(responseString, typeof(List<Cinema>)));
                        _cacheService.Set(city, cinemas, CacheExpiry(15.0));
                    }
                    catch
                    {
                        ShowGetFailedNotification();
                        return new ObservableCollection<Cinema>();
                    }
                }
                else
                {
                    ShowConnectionNotification();
                    return new ObservableCollection<Cinema>();
                }
            }

            return cinemas;
        }

        public async Task<List<string>> GetCities()
        {
            List<string> cities = _cacheService.Get<List<string>>("cities");

            if (cities == null)
            {
                if (_connectivity.EnsureInternetAccess())
                {
                    var uri = ResourceIdentifier.CityUri();
                    try
                    {
                        var responseString = await _httpService.Get(uri);
                        cities = (List<string>)_jsonConverter.DeserializeObject(responseString, typeof(List<string>));
                        _cacheService.Set("cities", cities, CacheExpiry(15.0));
                    }
                    catch
                    {
                        ShowGetFailedNotification();
                        return new List<string>();
                    }
                }
                else
                {
                    ShowConnectionNotification();
                    return new List<string>();
                }
            }

            return cities;
        }

        public async Task<MovieDetails> GetMovie(long id)
        {
            var key = String.Format("movie{0}", id);
            MovieDetails movie = _cacheService.Get<MovieDetails>(key);

            if (movie == null)
            {
                if (_connectivity.EnsureInternetAccess())
                {
                    var uri = ResourceIdentifier.MovieUri(id);
                    try
                    {
                        var responseString = await _httpService.Get(uri);
                        movie = (MovieDetails)_jsonConverter.DeserializeObject(responseString, typeof(MovieDetails));
                        _cacheService.Set(key, movie, CacheExpiry(15.0));
                    }
                    catch
                    {
                        ShowGetFailedNotification();
                        return new MovieDetails();
                    }
                }
                else
                {
                    ShowConnectionNotification();
                    return new MovieDetails();
                }
            }

            return movie;
        }

        public async Task<List<Rating>> GetRating(long cinemaId, long movieId)
        {
            var key = String.Format("rating{0}-{1}", cinemaId, movieId);
            List<Rating> rating = _cacheService.Get<List<Rating>>(key);
            var uri = ResourceIdentifier.RatingUri(cinemaId, movieId);
            if (_connectivity.EnsureInternetAccess())
            {
                try
                {
                    var responseString = await _httpService.Get(uri);
                    rating = (List<Rating>)_jsonConverter.DeserializeObject(responseString, typeof(List<Rating>));
                    _cacheService.Set(key, rating, CacheExpiry(15.0));
                }
                catch
                {
                    ShowGetFailedNotification();
                    return new List<Rating>();
                }
            }
            else
            {
                ShowConnectionNotification();
                return new List<Rating>();
            }

            return rating;
        }
    }
}
