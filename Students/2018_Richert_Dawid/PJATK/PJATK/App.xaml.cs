using FreshMvvm;
using PJATK.ViewModels;
using Xamarin.Forms;

namespace PJATK
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

            var splashPage = FreshPageModelResolver.ResolvePageModel<SplashViewModel>();
            MainPage = new FreshNavigationContainer(splashPage);
        }

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
