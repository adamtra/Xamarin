using PatientsStory.Models;
using PatientsStory.Views;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace PatientsStory.ViewModels
{
    public class PatientsListViewModel : BaseViewModel
    {
        public PatientsListViewModel()
        {
            RefreshCommand.Execute(null);
        }

        private Patient _selectedPatient;
        public Patient SelectedPatient
        {
            get { return _selectedPatient; }
            set
            {
                _selectedPatient = value;
                if (_selectedPatient == null)
                {
                    return;
                }
                SelectPatient.Execute(_selectedPatient);
                _selectedPatient = null;
                OnPropertyChanged("SelectedPatient");
            }
        }

        private ObservableCollection<Patient> _patientsList;
        public ObservableCollection<Patient> PatientsList
        {
            get
            {
                return _patientsList;
            }
            set
            {
                _patientsList = value;
                OnPropertyChanged("PatientsList");
            }
        }

        private bool _isRefreshing;
        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set
            {
                _isRefreshing = value;
                OnPropertyChanged("IsRefreshing");
            }
        }

        public Command AddPatient
        {
            get
            {
                return new Command(async () =>
                {
                    var patientAddViewModel = new PatientAddViewModel();
                    var patientAddPage = new PatientAddPage(patientAddViewModel);
                    await Application.Current.MainPage.Navigation.PushAsync(patientAddPage);
                });
            }
        }

        public Command SelectPatient
        {
            get
            {
                return new Command(async () =>
                {
                    var patientDetailsViewModel = InitPatientDetailsViewModel();
                    var patientDetailsPage = new PatientDetailsPage(patientDetailsViewModel);
                    await Application.Current.MainPage.Navigation.PushAsync(patientDetailsPage);
                });
            }
        }

        public Command RefreshCommand
        {
            get
            {
                return new Command(async () =>
                {
                    IsRefreshing = true;
                    var patients = await App.Database.GetPatientsAsync();
                    PatientsList = new ObservableCollection<Patient>(patients);
                    IsRefreshing = false;
                });
            }
        }

        #region Helpers

        private PatientDetailsViewModel InitPatientDetailsViewModel()
        {
            return new PatientDetailsViewModel
            {
                PatientId = _selectedPatient.PatientId,
                FirstName = _selectedPatient.FirstName,
                LastName = _selectedPatient.LastName,
                FullName = _selectedPatient.FullName,
                PESEL = _selectedPatient.PESEL,
                Age = _selectedPatient.Age.ToString(),
                Gender = _selectedPatient.Gender
            };
        }

        #endregion
    }
}