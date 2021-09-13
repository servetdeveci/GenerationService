using Newtonsoft.Json;
using PowerPlant.Domain.Entities;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace PowerPlant.IntegrationTests
{
    public class GettingApiData : IClassFixture<TestFixture>
    {
        private readonly HttpClient _client;

        public GettingApiData(TestFixture fixture)
        {
            _client = fixture.Client;
        }

        [Fact]
        public async Task Challenge_Get_All_Power_Plants()
        {
            // Ayarla
            var request = new HttpRequestMessage(HttpMethod.Get, "/api/PowerPlant");

            // Cagir
            var response = await _client.SendAsync(request);
            var b = response.Content.ReadAsStringAsync().Result;
            var pps = JsonConvert.DeserializeObject<List<PowerPlantDef>>(b);

            // kontrol et
            Assert.NotNull(pps);
        }
    }
}