using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBook_ADO.NET
{
    public class Contact
    {
        public int ContactID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string AddressBookName { get; set; }
        public string ContactType { get; set; }
        public DateTime Date_added { get; set; }

        // Default Constructor
        public Contact()
        {

        }

        // Parameterised Constructor
        public Contact(string firstName, string lastName, string address, string city, string state, string zipCode, string phoneNumber, string email, string addressBookName, string contactType, DateTime date_added)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            City = city;
            State = state;
            ZipCode = zipCode;
            PhoneNumber = phoneNumber;
            Email = email;
            AddressBookName = addressBookName;
            ContactType = contactType;
            Date_added = date_added;
        }
    }
}
