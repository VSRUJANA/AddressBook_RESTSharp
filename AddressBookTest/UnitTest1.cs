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
            AddressBookRepo addressBookRepo = new AddressBookRepo();
            bool expected = true;

            bool result = addressBookRepo.RetrieveFromDatabase();

            Assert.AreEqual(expected, result);
        }
    }
}
