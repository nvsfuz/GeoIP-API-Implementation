namespace ApiImplementation
{
	using System.Threading.Tasks;
	using GeoIp.Models;
	using GeoIp.Providers;

	public class GeoIpService
	{
		private readonly GeoIpDataProvider provider;

		public GeoIpService(GeoIpDataProvider provider)
		{
			this.provider = provider;
		}

		public async Task<GeoIpInfo> GetGeoIpInfo(string ipOrHostname)
		{
			return await this.provider.GetData(ipOrHostname);
		}
	}
}
