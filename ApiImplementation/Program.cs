using System;
using System.Threading.Tasks;

namespace ApiImplementation
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                ApiHelper.InitializeClient();
                RunAsync().GetAwaiter().GetResult();
                Console.ReadKey();
            } while (true);
        }

        static async Task RunAsync()
        {
            int apiChoice = 0;

            try
            {
                Console.Write("Enter IP or Hostname: ");
                string path = Console.ReadLine();

                // Loop will continue to ask for int 1 or 2 until one is chosen.
                do
                {
                    try
                    {
                        Console.Clear();
                        Console.Write("Would you like to use api.ipstack or ip.api?\n1: api.ipstack\n2: ip.api\nChoice: ");
                        apiChoice = Convert.ToInt32(Console.ReadLine());
                        if (apiChoice != 1 && apiChoice != 2)
                        {
                            Console.WriteLine("Your input must be either 1 or 2!");
                            Console.ReadKey();
                        }
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine("Your input must be a number!\n\n" + ex);
                        Console.ReadKey();
                    }
                } while (apiChoice != 1 && apiChoice != 2);

                Console.Clear();

                // Shows which API was used, unless IpOrHostname is blank and ipstack is used
                // ip.api defaults to own ip if no IpOrHostname is specified
                if (apiChoice == 1)
                {
                    Console.WriteLine("API: ip.api");
                }
                else if (apiChoice == 2)
                {
                    Console.WriteLine("API: api.ipstack");
                }
                else
                {
                    throw new InvalidOperationException("Invalid query.");
                }

                GeoIpInfo geo = await GeoIpService.GetGeoIpInfo(path, apiChoice);
                Console.WriteLine("IP Adress: " + geo.Ip + 
                    "\nCity: " + geo.City + 
                    "\nCountry: " + geo.Country + 
                    "\nLatitude: " + geo.Latitude + 
                    "\nLongitude: " + geo.Longitude + 
                    "\nRegion: " + geo.RegionCode + 
                    "\nZip Code: " + geo.ZipCode + 
                    "\nTimezone: " + geo.TimeZone);
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("An error occured!\nError code: " + e + "\n\nTry again.");
            }
        }
    }
}
