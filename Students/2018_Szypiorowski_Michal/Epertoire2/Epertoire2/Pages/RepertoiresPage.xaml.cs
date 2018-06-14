using Epertoire2.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Epertoire2.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RepertoiresPage : ContentPage
	{
		public RepertoiresPage ()
		{
            InitializeComponent ();
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();
            context.Refresh();
        }

        private async void OnListViewItemTapped(object sender, ItemTappedEventArgs e)
        {
            var item = e.Item as MovieShows;
            var showPage = new ShowPage(item);

            await Navigation.PushAsync(showPage);
        }

        private async void OnToolbarItemFilterClicked(object sender, ClickedEventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new FilterPage()));
        }

        private async void OnToolbarItemSettingsClicked(object sender, ClickedEventArgs e)
        {
            await Navigation.PushAsync(new SettingsPage());
        }
    }
}
