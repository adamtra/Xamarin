using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using Books.Models;
using Books.Views;

namespace Books.ViewModels
{
    public class BooksViewModel : BaseViewModel
    {
        public ObservableCollection<Book> Books { get; set; }
        public Command LoadItemsCommand { get; set; }

        public BooksViewModel()
        {
            Title = "Lista książek";
            Books = new ObservableCollection<Book>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NewBookPage, Book>(this, "AddItem", async (obj, book) =>
            {
                var _book = book as Book;
                Books.Add(_book);
                await App.Database.SaveItemAsync(_book);
            });
        }

        public Command AddBookButton
        {
            get
            {
                return new Command(async () =>
                {
                    await App.Current.MainPage.Navigation.PushModalAsync(new NavigationPage(new NewBookPage()));

                });
            }
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Books.Clear();
                var books = await App.Database.GetBooksAsync();
                foreach (var book in books)
                {
                    Books.Add(book);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}