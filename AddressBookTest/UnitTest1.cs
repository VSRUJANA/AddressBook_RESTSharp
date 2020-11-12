using Microsoft.VisualStudio.TestTools.UnitTesting;
using AddressBook_ADO.NET;

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
    }
}
