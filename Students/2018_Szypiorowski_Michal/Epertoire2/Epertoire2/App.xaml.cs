using Epertoire2.Pages;
using Epertoire2.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Epertoire2
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

            MainPage = new NavigationPage(new RepertoiresPage());
		}

        private void Setup()
        {
            var dataStorage = DependencyService.Get<IDataStorage>();
            Task.Run(() => dataStorage.GetCities());
        }

		protected override void OnStart ()
		{
            // Handle when your app starts
            Setup();
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
            // Handle when your app resumes
            Setup();
		}
	}
}
