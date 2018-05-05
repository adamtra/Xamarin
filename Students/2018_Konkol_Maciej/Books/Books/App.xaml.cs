using System;
using System.Diagnostics;
using System.Linq;
using books.data;
using Books.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Books
{

    public partial class App : Application
    {

        static BooksDatabase database;

        public static Page LastPage { get; set; }

        public AboutPage AboutPage { get; }

        public App()
        {
            InitializeComponent();
            MainPage = new MainPage();
            AboutPage = new AboutPage();
        }
        public static BooksDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new BooksDatabase(DependencyService.Get<IFileHelper>().GetLocalFilePath("Books.db3"));
                }
                return database;
            }
        }
        protected override void OnStart()
        {

            Debug.WriteLine("OnStart");
            Debug.WriteLine(DateTime.Now);
        }

        protected override void OnSleep()
        {
            Debug.WriteLine("OnSleep");

        }

        protected override void OnResume()
        {
            App.Current.MainPage.Navigation.PushModalAsync(new NavigationPage(new MainPage()));

            Debug.WriteLine("OnResume");
            base.OnResume();
        }
    }
}