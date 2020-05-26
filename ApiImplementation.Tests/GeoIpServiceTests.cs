namespace ApiImplementation.Tests
{
    using System;
    using Xunit;
    using ApiImplementation;
    using Moq;
    using ApiImplementation.Providers;

    public class GeoIpServiceTests
    {
        string path = "www.pintle.dk";

        [Fact]
        public void GeoIpService_DataProvider_IpApiProvidesCorrectData()
        {
            var geoService = new Mock<GeoIpService>(new IpApiGeoIpDataProvider());
            var actual = geoService.Setup(x => x.GetGeoIpInfo(path).Result);

           
        }
    }
}
