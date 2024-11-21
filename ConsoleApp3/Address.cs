using ClientInfo;
using System.Transactions;
using MUI;


namespace FullAddress
{
    public class Address
    {
        public string Unit { get; set; }
        public string Streetnumber { get; set; }
        public string Streetname { get; set; }
        public string Streetsuffix { get; set; }
        public string City { get; set; }
        public string Postcode { get; set; }
        public string State { get; set; }

        public Address(string unit, string streetnumber, string streetname, string streetsuffix, string city, string postcode, string state)
        {
            Unit = unit;
            Streetnumber = streetnumber;
            Streetname = streetname;
            Streetsuffix = streetsuffix;
            City = city;
            Postcode = postcode;
            State = state;

        }
        public static Address GetValidAddress()
        {
            return new Address(validunit(), validstreetnumber(), validstreetname(), validstreetsuffix(), validcity(), validpostcode(), validstate());
        }

        private static string validstate()
        {
            string city = "";
            while (true)
            {
                Console.WriteLine("State");
                Console.Write(">");
                city = Console.ReadLine();
                if (city.Contains("QLD") || city.Contains("NSW") || city.Contains("VIC") || city.Contains("NT") || city.Contains("WA") || city.Contains("SA") || city.Contains("TAS"))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter a valid state");
                    continue;
                }

            }
            return city;
        }
        private static string validunit()
        {
            while (true)
            {
                Console.WriteLine("Unit");
                Console.Write(">");
                var unit = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(unit))
                    continue;
                return unit;
            }

        }
        private static string validstreetnumber()
        {
            while (true)
            {
                Console.WriteLine("StreetNumber");
                Console.Write(">");
                var streetnumber = Console.ReadLine();
                bool AllDigits = false;
                foreach (var P in streetnumber)
                {
                    if (char.IsDigit(P))
                    {
                        AllDigits = true;


                    }
                    else
                    {
                        AllDigits = false;
                    }
                }
                if (AllDigits)
                {
                    return streetnumber;
                }
                continue;
            }
        }

        private static string validcity()
        {
            while (true)
            {
                Console.WriteLine("City");
                Console.Write(">");
                var city = Console.ReadLine();
                if (string.IsNullOrEmpty(city))
                {
                    continue;
                }
                return city;
            }



        }
        private static string validstreetname()
        {
            while (true)
            {
                Console.WriteLine("StreetName");
                Console.Write(">");
                var streetname = Console.ReadLine();
                if (!string.IsNullOrEmpty(streetname))
                {
                    return streetname;
                }
                else
                {
                    Console.WriteLine("Invalid street name try again");
                    continue;
                }
            }
        }
        private static string validstreetsuffix()
        {
            while (true)
            {
                Console.WriteLine("StreetSuffix");
                Console.Write(">");
                var streetsuffix = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(streetsuffix))
                {
                    Console.WriteLine("Invalid Suffix!");
                    continue;
                }
                return streetsuffix;
            }
        }
        private static string validpostcode()
        {
            string Postcode = "";
            while (true)
            {
                Console.WriteLine("Postcode");
                Console.Write(">");
                Postcode = Console.ReadLine();
                bool validinput = false;
                validinput = (int.TryParse(Postcode, out int postcode));
                if (postcode >= 1000 && postcode <= 9999)
                {
                    validinput = true;
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter a valid postcode");
                    continue;
                }


            }
            return Postcode;
        }


    }
}