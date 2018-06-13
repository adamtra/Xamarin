using Epertoire2.Model;
using Epertoire2.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Epertoire2.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MoviePage : ContentPage
	{
		public MoviePage(MovieShows movieShows)
		{
            BindingContext = new MovieViewModel(movieShows);
			InitializeComponent ();
		}

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);

            if (height > width)
            {
                ButtonStackLayout.Orientation = StackOrientation.Vertical;
            }
            else
            {
                ButtonStackLayout.Orientation = StackOrientation.Horizontal;
            }
        }
    }
}
