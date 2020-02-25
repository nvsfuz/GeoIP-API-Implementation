using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
            try
            {
                Console.Write("Enter IP or Hostname: ");
                string path = Console.ReadLine();
                GeoIpInfo geo = await GeoIpService.GetGeoIpInfo(path);
                Console.WriteLine("IP Adress: " + geo.Ip + "\nCity: " 
                    + geo.City + "\nCountry: " + geo.Country + "\nLatitude: " 
                    + geo.Latitude + "\nLongitude: " + geo.Longitude + "\nRegion: " 
                    + geo.RegionCode + "\nZip Code: " + geo.ZipCode + "\nTimezone: " + geo.TimeZone);
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occured!\nError code: " + e + "\n\nTry again.");
            }
        }
    }

}
