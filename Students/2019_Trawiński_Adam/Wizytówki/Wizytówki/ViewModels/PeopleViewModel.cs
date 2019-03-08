using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Wizytówki.Models;
using Wizytówki.Services;
using Xamarin.Forms;

namespace Wizytówki.ViewModels
{
    public class PeopleViewModel : BaseViewModel
    {
        public ObservableCollection<Person> People { get; set; }
        public Command LoadPeopleCommand { get; set; }

        public PeopleViewModel()
        {
            People = new ObservableCollection<Person>();
            LoadPeopleCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                People.Clear();
                List<Person> people = DependencyService.Get<IFileReadWrite>().GetAll();
                foreach (Person p in people)
                {
                    People.Add(p);
                }
            }
            catch (Exception) {}
            finally
            {
                IsBusy = false;
            }
        }
    }
}
