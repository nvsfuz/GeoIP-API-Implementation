namespace ApiImplementation
{
    using System;
    using System.Threading.Tasks;
    using static System.Console;

    using Providers;

    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Clear();
                RunAsync().GetAwaiter().GetResult();
                ReadKey();
            } while (true);
        }

        static async Task RunAsync()
        {
            int apiChoice = 0;

            try
            {
                Write("Enter IP or Hostname: ");
                string path = ReadLine();

                // Loop will continue to ask for int 1 or 2 until one is chosen.
                do
                {
                    try
                    {
                        Clear();
                        Write("Would you like to use api.ipstack or ip.api?\n1: api.ipstack\n2: ip.api\nChoice: ");
                        apiChoice = Convert.ToInt32(ReadLine());
                        if (apiChoice != 1 && apiChoice != 2)
                        {
                            WriteLine("Your input must be either 1 or 2!");
                            ReadKey();
                        }
                    }
                    catch (FormatException ex)
                    {
                        WriteLine("Your input must be a number!\n\n" + ex);
                        ReadKey();
                    }
                } while (apiChoice != 1 && apiChoice != 2);

                Clear();

                GeoIpDataProvider provider = null;

                // Shows which API was used, unless IpOrHostname is blank and ipstack is used
                // ip.api defaults to own ip if no IpOrHostname is specified
                if (apiChoice == 1)
                {
                    WriteLine("API: ip.api");
                    provider = new IpApiGeoIpDataProvider();
                }
                else if (apiChoice == 2)
                {
                    WriteLine("API: api.ipstack");
                    provider = new IpStackGeoIpDataProvider();
                }
                else
                {
                    throw new InvalidOperationException("Invalid query.");
                }

                var service = new GeoIpService(provider);

                var geo = await service.GetGeoIpInfo(path);

                WriteLine("IP Adress: " + geo.Ip +
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
                WriteLine("An error occured!\nError code: " + e + "\n\nTry again.");
            }
        }
    }
}
