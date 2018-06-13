using Epertoire2.Model;
using Epertoire2.Model.Entities;
using Epertoire2.Resources;
using Epertoire2.Services;
using PropertyChanged;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Epertoire2.ViewModels
{
    public class MovieViewModel : ViewModel
    {
        private readonly IDataStorage _dataStorage;
        private CinemaDetails _cinema;

        public double AverageRating { get; set; }
        public double CleanlinessRating { get; set; }
        public double ScreenRating { get; set; }
        public double SeatsRating { get; set; }
        public double SnacksRating { get; set; }
        public double SoundRating { get; set; }
        public string Cast { get; set; }
        public string Description { get; set; }
        public string Director { get; set; }
        public string Genres { get; set; }
        public string Title { get; set; }
        public string Shows { get; set; }

        public ICommand OpenWebsite { get; set; }
        public ICommand OpenYoutube { get; set; }

        public MovieViewModel(IDataStorage dataStorage, MovieShows movieShow)
        {
            _dataStorage = dataStorage;
            _cinema = Task.Run(() => _dataStorage.GetCinema(movieShow.Cinema)).Result;
            Genres = movieShow.Genres;
            Shows = movieShow.Shows;

            var movie = Task.Run(() => _dataStorage.GetMovie(movieShow.MovieId)).Result;
            var ratings = Task.Run(() => _dataStorage.GetRating(movieShow.CinemaId, movieShow.MovieId)).Result;
            foreach (var rating in ratings)
            {
                CleanlinessRating += rating.Cleanliness;
                ScreenRating += rating.Screen;
                SeatsRating += rating.Comfort;
                SnacksRating += rating.Snacks;
                SoundRating += rating.Sound;
            }

            CleanlinessRating = CleanlinessRating / ratings.Count;
            ScreenRating /= ratings.Count;
            SeatsRating /= ratings.Count;
            SnacksRating /= ratings.Count;
            SoundRating /= ratings.Count;
            AverageRating = (CleanlinessRating + ScreenRating + SeatsRating + SnacksRating + SoundRating) / 5;

            Cast = movie.Cast;
            Description = movie.Storyline;
            Director = movie.Director;
            Title = movie.OriginalName;

            OpenWebsite = new Command(VisitWebsite);
            OpenYoutube = new Command(VisitYoutube);
        }

        public MovieViewModel(MovieShows movieShow) : this(DependencyService.Get<IDataStorage>(), movieShow)
        {

        }

        private void VisitYoutube()
        {
            var uri = ResourceIdentifier.YoutubeUri(Title);
            Device.OpenUri(new System.Uri(uri));
        }

        private void VisitWebsite()
        {
            switch ((CinemaType)_cinema.CinemaType)
            {
                case CinemaType.CinemaCity:
                    var uri = ResourceIdentifier.CinemaCityUri(_cinema.Email);
                    Device.OpenUri(new System.Uri(uri));
                    break;
                case CinemaType.Multikino:
                    //var uri = ResourceIdentifier.MultikinoUri(_cinema.InternalId);
                    break;
            }
        }
    }
}
