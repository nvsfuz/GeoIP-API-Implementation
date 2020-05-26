
namespace GeoIp.Tests.GeoIpDataProviders
{
    using ApiImplementation.Providers;
    using Xunit;
    using Moq;
    using System.Threading.Tasks;

    public class IpStackGeoIpDataProviderTests
    {
        const string Host1 = "pintle.dk";
        const string ResponseExpample = @"{'ip':'18.197.120.96','type':'ipv4','continent_code':'EU','continent_name':'Europe','country_code':'DE','country_name':'Germany','region_code':'HE','region_name':'Hesse','city':'Frankfurt am Main','zip':'60311','latitude':50.11090087890625,'longitude':8.682100296020508,'location':{'geoname_id':2925533,'capital':'Berlin','languages':[{'code':'de','name':'German','native':'Deutsch'}],'country_flag':'http:\/\/assets.ipstack.com\/flags\/de.svg','country_flag_emoji':'\ud83c\udde9\ud83c\uddea','country_flag_emoji_unicode':'U+1F1E9 U+1F1EA','calling_code':'49','is_eu':true}}";
        private IpStackGeoIpDataProvider mockedProvider;
        private const string ApiPath = "http://api.ipstack.com/";
        private const string ApiSuffix = "?access_key=6321b3b977c6c1dc41e59b05728d7cd0";
        public IpStackGeoIpDataProviderTests()
        {
            var mock = new Mock<IpStackGeoIpDataProvider>();
            mock.CallBase = true;
            mock.Setup(x => x.GetStringResponseAsync(ApiPath + Host1 + ApiSuffix)).Returns(Task.FromResult(ResponseExpample));

            this.mockedProvider = mock.Object;
        }

        [Fact]
        public async Task GetData_DeliversDataToModel()
        {
            var actual = await this.mockedProvider.GetData(Host1);

            Assert.Equal("Germany", actual.Country);
        }
    }
}
