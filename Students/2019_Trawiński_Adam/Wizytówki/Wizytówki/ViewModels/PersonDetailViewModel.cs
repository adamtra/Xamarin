using System;
using System.Collections.Generic;
using System.Text;
using Wizytówki.Models;

namespace Wizytówki.ViewModels
{
    public class PersonDetailViewModel : BaseViewModel
    {
        public Person Person { get; set; }
        public PersonDetailViewModel(Person person = null)
        {
            Title = person.FirstName + " " + person.LastName;
            Person = person;
        }
    }
}
