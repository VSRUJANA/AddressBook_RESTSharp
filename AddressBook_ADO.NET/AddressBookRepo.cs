﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace AddressBook_ADO.NET
{
    public class AddressBookRepo
    {
        string connectionString = @"Data Source=LAPTOP-BSJLU8TT\SQLEXPRESS;Initial Catalog=Address_Book_Service;Integrated Security=True";
        SqlConnection connection;
        public bool RetrieveFromDatabase()
        {
            connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    string query = "select contact.Contact_ID,FirstName,LastName,AddressBookName,ContactType,Address,City,State,Zipcode,PhoneNumber,Email from Contact_Details contact inner join Contact_Type type on (contact.Contact_ID = type.ContactID)";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    this.connection.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        Console.WriteLine("ID".PadRight(4) + "FirstName".PadRight(12) + "LastName".PadRight(12) + "BookName".PadRight(10) + "ContactType".PadRight(15) + "Address".PadRight(20) + "City".PadRight(18) + "State".PadRight(12) + "Zip".PadRight(10) + "Phone No.".PadRight(15) + "Email".PadRight(12));
                        while (reader.Read())
                        {
                            Contact contact = new Contact();
                            contact.ContactID = reader.GetInt32(0);
                            contact.FirstName = !reader.IsDBNull(1) ? reader.GetString(1) : "NA";
                            contact.LastName = !reader.IsDBNull(2) ? reader.GetString(2) : "NA";
                            contact.AddressBookName = !reader.IsDBNull(3) ? reader.GetString(3) : "NA";
                            contact.ContactType = !reader.IsDBNull(4) ? reader.GetString(4) : "NA";
                            contact.Address = !reader.IsDBNull(5) ? reader.GetString(5) : "NA";
                            contact.City = !reader.IsDBNull(6) ? reader.GetString(6) : "NA";
                            contact.State = !reader.IsDBNull(7) ? reader.GetString(7) : "NA";
                            contact.ZipCode = !reader.IsDBNull(8) ? reader.GetString(8) : "NA";
                            contact.PhoneNumber = !reader.IsDBNull(9) ? reader.GetString(9) : "NA";
                            contact.Email = !reader.IsDBNull(10) ? reader.GetString(10) : "NA";
                            Console.Write(contact.ContactID.ToString().PadRight(4) + contact.FirstName.PadRight(12) + contact.LastName.PadRight(12));
                            Console.Write(contact.AddressBookName.PadRight(10) + contact.ContactType.PadRight(15) + contact.Address.PadRight(20));
                            Console.Write(contact.City.PadRight(18) + contact.State.PadRight(12) + contact.ZipCode.PadRight(10) + contact.PhoneNumber.PadRight(15) + contact.Email.PadRight(12));
                            Console.Write("\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No records in the database!");
                    }
                    return true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
