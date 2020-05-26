namespace GeoIp.Providers
{
	using System.Net.Http;
	using System.Net.Http.Headers;
	using System.Threading.Tasks;
	using Models;

	public abstract class GeoIpDataProvider
	{
		public abstract Task<GeoIpInfo> GetData(string ipOrHostname);

		protected HttpClient ApiClient { get; }

		protected GeoIpDataProvider()
		{
			this.ApiClient = new HttpClient();
			this.ApiClient.DefaultRequestHeaders.Accept.Clear();
			this.ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
		}

		public virtual async Task<string> GetStringResponseAsync(string path)
		{
			using (var response = await this.ApiClient.GetAsync(path))
			{
				return await response.Content.ReadAsStringAsync();
			}
		}
	}
}