using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Wizytówki.Models;
using Wizytówki.Services;
using Wizytówki.Validators;
using Xamarin.Forms;

namespace Wizytówki.ViewModels
{
    public class PersonViewModel : BaseViewModel
    {
        private string _firstName;
        private string _lastName;
        private string _phoneNumber;
        private string _emailAddress;

        private string _firstNameError = "";
        private string _lastNameError = "";
        private string _phoneNumberError = "";
        private string _emailAddressError = "";
        public string FirstName
        {
            get => _firstName;
            set
            {
                _firstName = value;
                OnPropertyChanged();
                FirstNameError = !ValidateFirstName() ? "Imię nie może być puste" : "";
            }
        }

        public string FirstNameError
        {
            get => _firstNameError;
            set
            {
                _firstNameError = value;
                OnPropertyChanged();
            }
        }

        public string LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
                OnPropertyChanged();
                LastNameError = !ValidateLastName() ? "Nazwisko nie może być puste" : "";
            }
        }

        public string LastNameError
        {
            get => _lastNameError;
            set
            {
                _lastNameError = value;
                OnPropertyChanged();
            }
        }

        public string PhoneNumber
        {
            get => _phoneNumber;
            set
            {
                _phoneNumber = value;
                OnPropertyChanged();
                PhoneNumberError = !ValidatePhoneNumber() ? "Numer telefonu musi być w formacie ###-###-###" : "";
            }
        }

        public string PhoneNumberError
        {
            get => _phoneNumberError;
            set
            {
                _phoneNumberError = value;
                OnPropertyChanged();
            }
        }

        public string EmailAddress
        {
            get => _emailAddress;
            set
            {
                _emailAddress = value;
                OnPropertyChanged();
                EmailAddressError = !ValidateEmailAddress() ? "Adres email musi być w poprawnym formacie" : "";
            }
        }

        public string EmailAddressError
        {
            get => _emailAddressError;
            set
            {
                _emailAddressError = value;
                OnPropertyChanged();
            }
        }

        private bool ValidateFirstName()
        {
            return ValidatorRules.IsNotNullOrEmpty(FirstName);
        }

        private bool ValidateLastName()
        {
            return ValidatorRules.IsNotNullOrEmpty(LastName);
        }

        private bool ValidatePhoneNumber()
        {
            return ValidatorRules.PhoneNumberValidation(PhoneNumber);
        }

        private bool ValidateEmailAddress()
        {
            return ValidatorRules.EmailValidation(EmailAddress);
        }


        private bool Validate()
        {
            return ValidateFirstName() && ValidateLastName() && ValidatePhoneNumber() && ValidateEmailAddress();
        }

        public ICommand AddPersonCommand => new Command(AddPerson);

        private void AddPerson()
        {
            bool isValid = Validate();
            if (isValid)
            {
                Person newPerson = new Person
                {
                    Id = Guid.NewGuid().ToString(),
                    FirstName = FirstName,
                    LastName = LastName,
                    PhoneNumber = PhoneNumber,
                    EmailAddress = EmailAddress
                };
                string fileName = newPerson.Id + ".txt";
                string data = newPerson.Id + "\n" + newPerson.FirstName + "\n" + newPerson.LastName + "\n" + newPerson.PhoneNumber + "\n" + newPerson.EmailAddress;
                DependencyService.Get<IFileReadWrite>().WriteData(fileName, data);
                ClearData();
            }
        }

        private void ClearData()
        {
            FirstName = "";
            FirstNameError = "";
            LastName = "";
            LastNameError = "";
            PhoneNumber = "";
            PhoneNumberError = "";
            EmailAddress = "";
            EmailAddressError = "";
        }

        public PersonViewModel(Person person = null)
        {
            _firstName = person?.FirstName;
            _lastName = person?.LastName;
            _phoneNumber = person?.PhoneNumber;
            _emailAddress = person?.EmailAddress;
        }
    }
 }
