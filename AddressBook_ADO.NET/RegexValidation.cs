using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace AddressBook_ADO.NET
{
    public class RegexValidation
    {

        public string emailID;
        public string phoneNo;
        public static string REGEX_EMAIL = "^[a-z0-9A-Z]+([._+-][a-z0-9A-Z]+)*[@][a-z0-9A-Z]+[.][a-zA-Z]{2,3}(.[a-zA-Z]{2,4})?$";
        public static string REGEX_MOB_NO = @"^[6-9]{1}[0-9]{9}$";

        // Validate Email ID
        public void ValidateEmail(string email)
        {
            emailID = email;
            bool validity = Regex.IsMatch(emailID, REGEX_EMAIL);
            if (!validity)
            {
                Console.Write("Invalid email id ! Enter valid email ID : ");
                email = Console.ReadLine();
                ValidateEmail(email);
            }
        }

        // Validate Phone Number
        public void ValidatePhoneNumber(string phoneNumber)
        {
            phoneNo = phoneNumber;
            bool validity = Regex.IsMatch(phoneNo, REGEX_MOB_NO);
            if (!validity)
            {
                Console.Write("Phone number entered is invalid! Enter valid Phone Number : ");
                phoneNumber = Console.ReadLine();
                ValidatePhoneNumber(phoneNumber);
            }
        }
    }
}
