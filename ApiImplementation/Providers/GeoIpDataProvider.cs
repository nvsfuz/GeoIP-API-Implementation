namespace ApiImplementation.Providers
{
	using System.Threading.Tasks;

	public abstract class GeoIpDataProvider
	{
		public abstract Task<GeoIpInfo> GetData(string ipOrHostname);
	}
}
