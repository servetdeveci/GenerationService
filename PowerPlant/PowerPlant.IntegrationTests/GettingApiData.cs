using Newtonsoft.Json;
using PowerPlant.Domain.Entities;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace PowerPlant.IntegrationTests
{
    public class GettingApiData : IClassFixture<ApiTestFixture>
    {
        private readonly HttpClient _client;

        public GettingApiData(ApiTestFixture fixture)
        {
            _client = fixture.Client;
        }

        [Fact]
        public async Task Challenge_Get_All_Power_Plants()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "api/PowerPlant");

            var response = await _client.SendAsync(request);
            var body = response.Content.ReadAsStringAsync().Result;
            var pps = JsonConvert.DeserializeObject<List<PowerPlantDef>>(body);

            Assert.NotNull(pps);
        }
    }
}