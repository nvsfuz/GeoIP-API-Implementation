namespace GeoIp.Tests
{
	using System.Threading.Tasks;
	using ApiImplementation;
	using Models;
	using Moq;
	using Providers;
	using Xunit;

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