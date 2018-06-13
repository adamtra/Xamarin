using Epertoire2.Model;
using Epertoire2.Model.Entities;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Epertoire2.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShowPage : TabbedPage
    {
        public ShowPage(MovieShows movieShows)
        {
            var moviePage = new MoviePage(movieShows)
            {
                Title = "Movie"
            };

            var cinemaPage = new CinemaPage(movieShows.Cinema)
            {
                Title = "Cinema"
            };

            InitializeComponent();
            Children.Add(moviePage);
            Children.Add(cinemaPage);
        }
    }
}