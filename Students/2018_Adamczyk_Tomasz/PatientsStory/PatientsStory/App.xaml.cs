using PatientsStory.Database;
using PatientsStory.Helpers;
using PatientsStory.ViewModels;
using PatientsStory.Views;
using System;
using Xamarin.Forms;

namespace PatientsStory
{
    public partial class App : Application
    {
        private static DatabaseController _database;
        private DateTime _sleepStart;
        private readonly TimeSpan _sleepLimit;

        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new PatientsListPage(new PatientsListViewModel()));
            _sleepLimit = TimeSpan.FromMinutes(30);
        }

        public static DatabaseController Database
        {
            get
            {
                if (_database == null)
                {
                    _database = new DatabaseController(DependencyService.Get<ILocalFileHelper>().GetLocalFilePath("database.db3"));
                }
                return _database;
            }
        }

        protected override void OnSleep()
        {
            _sleepStart = DateTime.Now;
        }

        protected override void OnResume()
        {
            if (DateTime.Now - _sleepStart > _sleepLimit)
            {
                MessagingCenter.Send(this, "The session has expired.");
            }
        }
    }
}