using Books.Models;
using Books.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Books.ViewModels
{
    public class NewBookViewModel : BaseViewModel
    {
        public Book Book { get; set; }

        public NewBookViewModel()
        {
            Book = new Book
            {
                BookName = "Wpisz nazwę książki która chcesz przeczytać",
                Author = "Autor",
                Description = "jakiś opis ksiązki."
            };
        }

        public Command SaveBook
        {
            get
            {
                return new Command(async () =>
                {
                    await App.Database.SaveItemAsync(Book);
                    await App.Current.MainPage.Navigation.PushModalAsync(new NavigationPage(new MainPage()));
                });
            }
        }
    }
}
