using System;

namespace AddressBook_ADO.NET
{
    class Program
    {
        static void Main(string[] args)
        {
            AddressBookRepo repo = new AddressBookRepo();
            RegexValidation validator = new RegexValidation();
            bool loop = true;
            while (loop)
            {
                Console.Write("----------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("Menu : \n1. View all records \n2. Update PhoneNumber and Email \n3. Retrieve Contacts added in given date range \n4. Exit");
                Console.Write("Enter choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        repo.RetrieveFromDatabase();
                        break;
                    case 2:
                        Contact contact = new Contact();
                        Console.Write("Enter FirstName : ");
                        contact.FirstName = Console.ReadLine();
                        Console.Write("Enter LastName  : ");
                        contact.LastName = Console.ReadLine();
                        if (repo.SearchContact(contact.FirstName, contact.LastName))
                        {
                            Console.Write("Enter PhoneNumber : ");
                            validator.ValidatePhoneNumber(Console.ReadLine());
                            contact.PhoneNumber = validator.phoneNo;
                            Console.Write("Enter Email ID : ");
                            validator.ValidateEmail(Console.ReadLine());
                            contact.Email = validator.emailID;
                            repo.UpdateContact(contact);
                        }                        
                        break;
                    case 3:
                        Console.Write("Enter start date : ");
                        string startDate = Console.ReadLine();
                        Console.Write("Enter end date   : ");
                        string endDate = Console.ReadLine();
                        repo.GetContactsAddedInDateRange(startDate, endDate);
                        break;
                    case 4:
                        loop = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice!");
                        break;

                }
            }
        }
    }
}
