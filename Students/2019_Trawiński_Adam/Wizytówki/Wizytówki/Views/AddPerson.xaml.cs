using System;
using Wizytówki.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Wizytówki.ViewModels;

namespace Wizytówki.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddPerson : ContentPage
	{
        MainPage RootPage { get => Application.Current.MainPage as MainPage; }
        private PersonViewModel viewModel;
        public AddPerson ()
		{
            InitializeComponent ();
            viewModel = new PersonViewModel();
            BindingContext = viewModel;
        }
    }
}