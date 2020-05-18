using System;

namespace ApiImplementation.Providers
{
	using System.Threading.Tasks;

	public class IpApiGeoIpDataProvider : GeoIpDataProvider
	{
		public override async Task<GeoIpInfo> GetData(string ipOrHostname)
		{
			// call api helper and get specific data

			// convert specific data to GeoIpInfo

			throw new NotImplementedException();
		}
	}
}