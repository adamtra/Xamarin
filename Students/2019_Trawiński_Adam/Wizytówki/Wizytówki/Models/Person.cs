using System;
using System.Collections.Generic;
using System.Text;

namespace Wizytówki.Models
{
    public class Person
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string FullName => string.Format("{0} {1}", FirstName, LastName);
    }
}
