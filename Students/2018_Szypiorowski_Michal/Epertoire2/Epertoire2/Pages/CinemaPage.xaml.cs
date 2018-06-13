using Epertoire2.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace Epertoire2.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CinemaPage : ContentPage
	{
        public CinemaPage(string cinemaName)
		{
            var context = new CinemaViewModel(cinemaName);
            BindingContext = context;
            InitializeComponent();
            map.Pins.Add(context.Pin);
            map.MoveToRegion(MapSpan.FromCenterAndRadius(context.Pin.Position, Distance.FromKilometers(2.5)));
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            if (height > width)
            {
                contentStackLayout.Orientation = StackOrientation.Vertical;
                map.HeightRequest = height / 2;
                map.WidthRequest = width;
            }
            else
            {
                contentStackLayout.Orientation = StackOrientation.Horizontal;
                map.HeightRequest = height;
                map.WidthRequest = width / 2;
            }
        }
    }
}