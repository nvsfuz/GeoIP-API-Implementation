namespace GeoIp.Tests.GeoIpDataProviders
{
	using System.Threading.Tasks;
	using NSubstitute;
	using Providers;
	using Xunit;

	public class IpApiGeoIpDataProviderTests
	{
		const string Host1 = "pintle.dk";
		const string ResponseExpample = "{'status':'success','country':'Germany','countryCode':'DE','region':'HE','regionName':'Hesse','city':'Frankfurt am Main','zip':'60313','lat':50.1109,'lon':8.68213,'timezone':'Europe / Berlin','isp':'Amazon Technologies Inc.','org':'AWS EC2(eu - central - 1)',' as':'AS16509 Amazon.com, Inc.','query':'18.197.120.96'}";
		private IpApiGeoIpDataProvider provider;

		public IpApiGeoIpDataProviderTests()
		{
			this.provider = Substitute.ForPartsOf<IpApiGeoIpDataProvider>();
			this.provider.GetStringResponseAsync("").ReturnsForAnyArgs(ResponseExpample);
		}

		[Fact]
        public async Task GetData_DeliversDataToModel()
        {
	        var actual = await this.provider.GetData(Host1);

			Assert.Equal("Germany", actual.Country);
        }
    }
}
