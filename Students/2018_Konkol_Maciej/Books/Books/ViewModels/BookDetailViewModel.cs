using System;

using Books.Models;
using Books.Views;
using Xamarin.Forms;

namespace Books.ViewModels
{
    public class BookDetailViewModel : BaseViewModel
    {
        public Book Book { get; set; }
        public BookDetailViewModel(Book item = null)
        {
            Title = item?.BookName;
            Book = item;
        }
        public Command DeleteBook
        {
            get
            {
                return new Command(async () =>
                {
                    await App.Database.DeleteItemAsync(Book);
                    await App.Current.MainPage.Navigation.PushModalAsync(new NavigationPage(new MainPage()));
                });
            }
        }

        public Command Comeback
        {
            get
            {
                return new Command(async () =>
                {
                    await App.Current.MainPage.Navigation.PopModalAsync();
                });
            }
        }
    }
 }
