using Newtonsoft.Json;
using PowerPlant.Domain.ViewModels;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace PowerPlant.IntegrationTests
{
    public class GenerationRandomData : IClassFixture<GenerationServiceTestFixture>
    {
        private readonly HttpClient _client;

        public GenerationRandomData(GenerationServiceTestFixture fixture)
        {
            _client = fixture.Client;
        }

        [Fact]
        public async Task Challenge_Get_PowerPlant_Hourly_Random_Data()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "generationservice/get?webId=12345678&startTime=2021/10/10 10:00:00&endTime=2021/10/11 10:00:00");

            var response = await _client.SendAsync(request);
            var responseBody = response.Content.ReadAsStringAsync().Result;
            var usages = JsonConvert.DeserializeObject<ApiResponse<TimedValues>>(responseBody);
            Assert.NotNull(usages.Data.Items);
        }
       
    }
}