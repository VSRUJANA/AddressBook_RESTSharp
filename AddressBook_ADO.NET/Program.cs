using System;

namespace AddressBook_ADO.NET
{
    class Program
    {
        static void Main(string[] args)
        {
            AddressBookRepo repo = new AddressBookRepo();
            repo.RetrieveFromDatabase();
        }
    }
}
