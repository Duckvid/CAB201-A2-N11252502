using MUI;
using System.Diagnostics;
using System;
using System.Collections.Generic;
using Products;
using System.Text.RegularExpressions;
namespace Auctionhouse
{
    public class Advertise
    {
        public static string ProductName()
        {
            while (true)
            {
                Console.WriteLine("Product Name:");
                Console.Write(">");
                var productname = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(productname))
                {
                    Console.WriteLine("Invalid Product Name!");
                    continue;
                }
                return productname;

            }
        }
        public static string ProductDescription()
        {
            while (true)
            {
                Console.WriteLine("Product Description");
                Console.Write(">");
                var productdescription = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(productdescription))
                {
                    Console.WriteLine("Invalid Product Description!");
                    continue;
                }
                return productdescription;
            }
        }
        public static string ProductPrice()
        {
            string productprice = "";
            while (true)
            {

                Console.WriteLine("Product Price");
                productprice = Console.ReadLine();
                if (string.IsNullOrEmpty(productprice))
                {
                    Console.WriteLine("Invalid price");
                    continue;
                }

                if (productprice[0] == '$')
                {
                    var split = productprice.Split('$');
                    var decimalCheck = split[1].Split('.');
                    if (decimalCheck.Length == 2)
                    {
                        if (decimalCheck[0].Length > 0 && decimalCheck[1].Length == 2)
                        {
                            return $"{split[1]:C}";
                        }
                    }
                }
                Console.WriteLine("Invalid price");
                continue;
            }
        }
    }


}
