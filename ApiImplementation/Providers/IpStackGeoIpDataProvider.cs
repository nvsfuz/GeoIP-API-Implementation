namespace ApiImplementation.Providers
{
	using System.Threading.Tasks;
	using System;

	public class IpStackGeoIpDataProvider : GeoIpDataProvider
	{
		public override async Task<GeoIpInfo> GetData(string ipOrHostname)
		{
			throw new NotImplementedException();
		}
	}
}
