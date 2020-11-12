using Microsoft.VisualStudio.TestTools.UnitTesting;
using AddressBook_ADO.NET;
using System.Collections.Generic;
using System;

namespace AddressBookTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Given_RetrieveContactsFromDatabase_ShouldReturnCount()
        {
            AddressBookRepo repo = new AddressBookRepo();
            bool expected = true;

            bool result = repo.RetrieveFromDatabase();

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void GivenNameFromDB_SearchContactShould_ReturnTrue()
        {
            AddressBookRepo repo = new AddressBookRepo();
            bool expected = true; 
            string firstName = "Edwin";
            string lastName = "Jarvis";

            bool result = repo.SearchContact(firstName, lastName);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void GivenNameNotInDB_SearchContactShould_ReturnFalse()
        {
            AddressBookRepo repo = new AddressBookRepo();
            bool expected = false;
            string firstName = "No";
            string lastName = "Contact";

            bool result = repo.SearchContact(firstName, lastName);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void GivenContactInfo_UpdateContactInformationShould_ReturnTrueIfUpdated()
        {
            AddressBookRepo repo = new AddressBookRepo();
            bool expected = true;
            Contact contact = new Contact();
            contact.FirstName = "Edwin";
            contact.LastName = "Jarvis";
            contact.PhoneNumber = "8987654637";
            contact.Email = "jarvisEdwin@gmail.com";

            bool result=repo.UpdateContact(contact);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Given_MultipleContactInfo_WhenAddedToDatabaseUsingThreads_Should_Return_NoOfContactsAdded()
        {
            AddressBookRepo addressBookRepo = new AddressBookRepo();
            List<Contact> contactList = new List<Contact>();
            int expected = 3;

            contactList.Add(new Contact("Tony","Stark","Stark Tower","Manhattan","NewYork","10001","8987224534","ironman@gmail.com","Home","Family",DateTime.Now));
            contactList.Add(new Contact("Pepper", "Potts", "Stark Tower", "Manhattan", "NewYork", "10001", "9987893534", "pepper@gmail.com", "Home", "Family", DateTime.Now));
            contactList.Add(new Contact("Peter", "Parker", "Queens", "NewYork City", "NewYork", "12240", "7013456376", "spiderman@yahoo.com", "Home", "Friends", DateTime.Now));
            int result = addressBookRepo.AddMultipleContactsUsingThreads(contactList);

            Assert.AreEqual(expected, result);
        }
    }
}
