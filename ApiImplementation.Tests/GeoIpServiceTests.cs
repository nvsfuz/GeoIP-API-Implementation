namespace ApiImplementation.Tests
{
	using System.Threading.Tasks;
    using Xunit;
    using ApiImplementation;
    using Moq;
    using Providers;

    public class GeoIpServiceTests
    {
	    private const string Host1 = "host1";
	    private readonly GeoIpInfo expectedForHost1 = new GeoIpInfo(Host1);

		private const string Host2 = "host2";
	    private readonly GeoIpInfo expectedForHost2 = new GeoIpInfo(Host2);

        private GeoIpDataProvider mockedProvider;

	    public GeoIpServiceTests()
	    {
            var mock = new Mock<GeoIpDataProvider>();
            mock.Setup(x => x.GetData(Host1)).ReturnsAsync(this.expectedForHost1);
            mock.Setup(x => x.GetData(Host2)).ReturnsAsync(this.expectedForHost2);

            this.mockedProvider = mock.Object;
	    }

        //[Fact]
        //public void GeoIpService_DataProvider_IpApiProvidesCorrectData()
        //{
        //    var geoService = new Mock<GeoIpService>(new IpApiGeoIpDataProvider());
        //    var actual = geoService.Setup(x => x.GetGeoIpInfo(path).Result);
        //}
        
        [Fact]
        public async Task GetGeoIpInfo_ReturnsDataFromProvider()
        {
            var service = new GeoIpService(this.mockedProvider);
            var actual = await service.GetGeoIpInfo(Host1);
            var actual2 = await service.GetGeoIpInfo(Host2);

            Assert.Equal(this.expectedForHost1.Ip, actual.Ip);
            Assert.Equal(this.expectedForHost2.Ip, actual2.Ip);
        }
    }
}