using System;
using System.Collections.Generic;

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
                Console.WriteLine("\nMenu : \n1. View all records \n2. Update PhoneNumber and Email \n3. Retrieve Contacts added in given date range \n" +
                    "4. Get Contacts count by City \n5. Get Contacts count by State \n6. Add New contact \n7.Add Multiple contacts using Threads\n8. Exit");
                Console.Write("Enter choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        repo.RetrieveFromDatabase();
                        break;
                    case 2:
                        Contact c = new Contact();
                        Console.Write("Enter FirstName : ");
                        c.FirstName = Console.ReadLine();
                        Console.Write("Enter LastName  : ");
                        c.LastName = Console.ReadLine();
                        if (repo.SearchContact(c.FirstName, c.LastName))
                        {
                            Console.Write("Enter Phone Number : ");
                            validator.ValidatePhoneNumber(Console.ReadLine());
                            c.PhoneNumber = validator.phoneNo;
                            Console.Write("Enter Email ID     : ");
                            validator.ValidateEmail(Console.ReadLine());
                            c.Email = validator.emailID;
                            repo.UpdateContact(c);
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
                        repo.GetCountByCity();
                        break;
                    case 5:
                        repo.GetCountByState();
                        break;
                    case 6:
                        Contact contact = new Contact();
                        Console.Write("Enter First Name : ");
                        contact.FirstName = Console.ReadLine();
                        Console.Write("Enter Last Name : ");
                        contact.LastName = Console.ReadLine();
                        if (repo.SearchContact(contact.FirstName, contact.LastName))
                        {
                            Console.WriteLine("Contact with name '{0} {1}' already exists!", contact.FirstName, contact.LastName);
                        }
                        else
                        {
                            Console.Write("Enter Address Book Name : ");
                            contact.AddressBookName = Console.ReadLine();
                            Console.Write("Enter Contact Type : ");
                            contact.ContactType = Console.ReadLine();
                            Console.Write("Enter Address : ");
                            contact.Address = Console.ReadLine();
                            Console.Write("Enter City : ");
                            contact.City = Console.ReadLine();
                            Console.Write("Enter State : ");
                            contact.State = Console.ReadLine();
                            Console.Write("Enter ZipCode : ");
                            contact.ZipCode = Console.ReadLine();
                            Console.Write("Enter Phone Number : ");
                            validator.ValidatePhoneNumber(Console.ReadLine());
                            contact.PhoneNumber = validator.phoneNo;
                            Console.Write("Enter Email ID : ");
                            validator.ValidateEmail(Console.ReadLine());
                            contact.Email = validator.emailID;
                            repo.AddContact(contact);
                        }
                        break;
                    case 7:
                        List<Contact> contactList = new List<Contact>();
                        while (true)
                        {
                            Contact newContact = new Contact();
                            Console.WriteLine("Enter the person details to be added in the address book");
                            Console.Write("Enter First Name : ");
                            newContact.FirstName = Console.ReadLine();
                            Console.Write("Enter Last Name : ");
                            newContact.LastName = Console.ReadLine();
                            if (repo.SearchContact(newContact.FirstName, newContact.LastName))
                            {
                                Console.WriteLine("Contact with name '{0} {1}' already exists!", newContact.FirstName, newContact.LastName);
                            }
                            else
                            {
                                Console.Write("Enter Address Book Name : ");
                                newContact.AddressBookName = Console.ReadLine();
                                Console.Write("Enter Contact Type : ");
                                newContact.ContactType = Console.ReadLine();
                                Console.Write("Enter Address : ");
                                newContact.Address = Console.ReadLine();
                                Console.Write("Enter City : ");
                                newContact.City = Console.ReadLine();
                                Console.Write("Enter State : ");
                                newContact.State = Console.ReadLine();
                                Console.Write("Enter ZipCode : ");
                                newContact.ZipCode = Console.ReadLine();
                                Console.Write("Enter Phone Number : ");
                                validator.ValidatePhoneNumber(Console.ReadLine());
                                newContact.PhoneNumber = validator.phoneNo;
                                Console.Write("Enter Email ID : ");
                                validator.ValidateEmail(Console.ReadLine());
                                newContact.Email = validator.emailID;
                                contactList.Add(newContact);
                            }
                            Console.WriteLine("Do you want to add more contacts ? Yes / No");
                            if (Console.ReadLine().ToUpper() == "NO")
                                break;
                        }
                        repo.AddMultipleContactsUsingThreads(contactList);
                        break;
                    case 8:
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
