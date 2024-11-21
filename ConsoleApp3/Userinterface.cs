using System;
using System.Collections.Generic;


using ClientInfo;
using FullAddress;
using Auctionhouse;


namespace MUI
{
    public class Bruh
    {

        public static void Main(string[] args)
        {
            UserData.LoadAll();
            bool running = true;
            while (running)
            {
                //Console.Clear();
                Console.WriteLine("Cool Auction house sample text i hate this");
                Console.WriteLine("Please choose one of the option:");
                Console.WriteLine("1) Login");
                Console.WriteLine("2) Register");
                Console.WriteLine("3) Exit");
                Console.Write("\r\nSelect an option: ");
                switch (Console.ReadLine())
                {
                    case "1":
                        var email = Client.GetValidEmail(true);
                        if (email == "INVALID")
                        {
                            Console.WriteLine("Invalid Email");
                            break;
                        }
                        if (UserData.DoesClientEmailExist(email))
                        {
                            Console.WriteLine("Valid Email");
                            var password = Client.validPassword();
                            if (UserData.DoesClientPasswordMatch(email, password))
                            {
                                Console.WriteLine("Provide password");
                                UserData.Login(email);
                                if (UserData.CurrentLogin.firstTimeLogin)
                                {
                                    FirstTimeMenu();
                                    UserData.SaveAll();

                                }
                                ClientMenu();
                            }
                            else
                            {
                                Console.WriteLine("Invalid password!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No matching email found");
                        }
                        //pass


                        break;
                    case "2":
                        Client client = new Client(Client.GetValidName(),
                        Client.validPassword(),
                        Client.GetValidEmail(),
                        null);
                        UserData.AddClient(client);
                        UserData.SaveAll();


                        break;
                    case "3":
                        UserData.SaveAll();
                        Environment.Exit(0);
                        break;
                    default: break;
                }
            }
        }
        private static void FirstTimeMenu()
        {
            bool running = true;
            while (running)
            {
                var client = UserData.CurrentLogin;
                client.Address = Address.GetValidAddress();
                return;
            }
        }
        public static void ClientMenu()
        {
            bool running = true;
            while (running)
            {
                Console.WriteLine("Welcome!");
                Console.WriteLine("Please select one of the option:");
                Console.WriteLine("1) Advertise Product");
                Console.WriteLine("2) View Product List");
                Console.WriteLine("3) Search Advertised Products");
                Console.WriteLine("4) View Bids On My Products");
                Console.WriteLine("5) View Purchased Items");
                Console.WriteLine("6) Log Off");
                Console.Write("\r\nSelect an option: ");
                switch (Console.ReadLine())
                {
                    case "1":
                        //advertise product
                        UserData.CurrentLogin.AddProduct(Auctionhouse.Advertise.ProductName(),
                        Auctionhouse.Advertise.ProductDescription(),
                        Auctionhouse.Advertise.ProductPrice());
                        UserData.SaveAll();
                        break;
                    case "2":
                        //View Product List
                        UserData.CurrentLogin.ViewPersonalProducts();
                        break;
                    case "3":
                        Console.WriteLine("Enter search phrase");
                        var searchPhrase = Console.ReadLine();
                        if (!string.IsNullOrEmpty(searchPhrase))
                        {
                            UserData.SearchProducts(searchPhrase);
                        }
                        break;
                    case "4":
                        break;
                    case "5":
                        break;
                    case "6":
                        UserData.Logout();
                        return;
                    default: break;
                }


            }

        }

    }

}





