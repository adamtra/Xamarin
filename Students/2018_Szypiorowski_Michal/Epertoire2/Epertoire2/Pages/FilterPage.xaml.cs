using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Epertoire2.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FilterPage : ContentPage
	{
		public FilterPage ()
		{
			InitializeComponent ();
		}

        private async void OnToolbarItemApplyClicked(object sender, ClickedEventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        private async void OnToolbarItemCancelClicked(object sender, ClickedEventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}
