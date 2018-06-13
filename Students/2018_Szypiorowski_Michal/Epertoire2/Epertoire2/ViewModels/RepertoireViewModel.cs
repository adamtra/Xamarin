using Epertoire2.Helpers;
using Epertoire2.Model;
using Epertoire2.Services;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Epertoire2.ViewModels
{
    public class RepertoireViewModel : ViewModel
    {
        private readonly IApplicationSettings _appSettings;
        private readonly IDataStorage _dataStorage;
        private readonly IFilter _filter;

        public ObservableCollection<Group<MovieShows>> Repertoires { get; set; }

        public RepertoireViewModel(IApplicationSettings appSettings, IDataStorage dataStorage, IFilter filter)
        {
            _appSettings = appSettings;
            _dataStorage = dataStorage;
            _filter = filter;

            Repertoires = new ObservableCollection<Group<MovieShows>>();
        }

        public RepertoireViewModel() : this(DependencyService.Get<IApplicationSettings>(),
                                            DependencyService.Get<IDataStorage>(),
                                            DependencyService.Get<IFilter>())
        {

        }

        public void Refresh()
        {
            Repertoires.Clear();
            var location = _appSettings.Location;
            if (location != null)
            {
                var cinemas = Task.Run(() => _dataStorage.GetCinemaRepertoires(location)).Result;
                foreach (var cinema in cinemas)
                {
                    var color = CinemaHelper.TextColor((CinemaType)cinema.CinemaType);
                    var displayName = String.Format("{0} {1}", cinema.CinemaName, cinema.CinemaCity);
                    var shortName = String.Format("{0}{1}", cinema.CinemaName.Substring(0, 2), cinema.CinemaCity.Substring(0, 1));
                    var group = new Group<MovieShows>(color, displayName, shortName);
                    foreach (var movie in cinema.Movies)
                    {
                        if (_filter.Check(movie))
                        {
                            var movieShow = new MovieShows(cinema.Id, movie.Id, group.DisplayName, movie.Title, movie.Genres, movie.Shows, movie.Rating);
                            group.Add(movieShow);
                        }
                    }

                    Repertoires.Add(group);
                }
            }
        }
    }
}
