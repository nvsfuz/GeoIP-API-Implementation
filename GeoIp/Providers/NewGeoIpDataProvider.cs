namespace GeoIp.Providers
{
	using System.Threading.Tasks;
	using Models;

	public class NewGeoIpDataProvider : GeoIpDataProvider<NewApiModel>
	{
		protected override async Task<GeoIpInfo> AdaptToTargetModel(NewApiModel data)
		{
			return new GeoIpInfo();
		}

		protected override async Task<string> CallTheApi(string ipOrHostname)
		{
			return string.Empty;
		}
	}
}
