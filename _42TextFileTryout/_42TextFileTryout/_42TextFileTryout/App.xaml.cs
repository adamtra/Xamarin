using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace _42TextFileTryout
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

			MainPage = new _42TextFileTryout.TextFileTryoutPage();
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
