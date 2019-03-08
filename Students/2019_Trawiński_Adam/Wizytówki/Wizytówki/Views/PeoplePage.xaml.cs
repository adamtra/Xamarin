using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Wizytówki.Models;
using Wizytówki.Services;
using Wizytówki.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Wizytówki.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PeoplePage : ContentPage
    {
        PeopleViewModel viewModel;

        public PeoplePage()
        {
            InitializeComponent();
            BindingContext = viewModel = new PeopleViewModel();
        }

        async void Handle_ItemTapped(object sender, SelectedItemChangedEventArgs args)
        {
            var person = args.SelectedItem as Person;
            if (person == null)
                return;

            await Navigation.PushAsync(new PersonDetailPage(new PersonDetailViewModel(person)));

            MyListView.SelectedItem = null;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            viewModel.LoadPeopleCommand.Execute(null);
        }
    }
}
