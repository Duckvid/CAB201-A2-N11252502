using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using MUI;
using FullAddress;
using System.Text.RegularExpressions;
using Products;
namespace ClientInfo
{
    public class Client
    {
        public string Fullname { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public Address Address { get; set; }

        public List<Item> products { get; set; }

        public List<Bid> bids { get; set; }

        public bool firstTimeLogin { get; set;}

        public Client(string fullname, string password, string email, Address address)
        {
            Fullname = fullname;
            Password = password;
            Email = email;
            Address = address;
        }

        public void AddProduct(string name, string description, string price)
        {
            var item = new Item();
            item.Name = name;
            item.Description = description;
            item.price = price;
            item.bid = null;
            if(products == null)
            {
                products = new List<Item>();
            }
            products.Add(item);
        }

        public void ViewPersonalProducts()
        {
            Console.WriteLine("Item # \t Product Name \t Description \t List Price \t Bidder name \t bidder email \t Bidder amt");
            int count = 1;
            foreach (var item in products)
            {
                string bidderName = "-";
                string bidderEmail = "-";
                string bidAmt = "-";
                if (item.bid != null)
                {
                    bidderName = $"{item.bid.Bidder.Fullname}";
                    bidderEmail = $"{item.bid.Bidder.Email}";
                    bidAmt = $"{item.bid.BidPrice:C}";
                }
                Console.WriteLine($"{item.Name} \t {item.Description} \t {item.price} \t {item} \t {bidderName} \t {bidderEmail} \t {bidAmt}");
                count++;
            }
        }
        public static string GetValidName()
        {
            while (true)
            {
                Console.WriteLine("Fullname");
                Console.Write(">");
                var fullname = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(fullname))
                {
                    Console.WriteLine("Invalid Name!");
                    continue;
                }
                return fullname;
            }
        }
        public static string GetValidEmail(bool breakIfIncorrect = false)
        {
            while (true)
            {
                Console.WriteLine("Email");
                Console.Write(">");
                var email = Console.ReadLine();

                if (email.Contains("@") && email.Contains("."))
                {
                    var split = email.Split('@');
                    if (split.Length == 2)
                    {

                        if (email[0] == '.' || email[0] == '@' || email[^1] == '.' || email[^1] == '.')
                        {
                            return email;
                        }

                    }
                }
                else
                {
                    if (breakIfIncorrect)
                    {
                        break;
                    }
                    Console.WriteLine("Invalid email was provided. Please try again.");
                    continue;
                }
                return email;
            }
            return "INVALID";

        }
        public static string validPassword()
        {
            string password = "";
            while (true)
            {
                Console.WriteLine("Password");
                Console.Write(">");
                password = Console.ReadLine();
                var hasNumber = new Regex(@"[0-9]+");
                var hasUpperChar = new Regex(@"[A-Z]+");
                var hasMinimum8Chars = new Regex(@".{8,}");
                if (hasNumber.IsMatch(password) && hasUpperChar.IsMatch(password) && hasMinimum8Chars.IsMatch(password))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter a valid password");
                    continue;
                }

            }
            return password;

        }
    }

}





