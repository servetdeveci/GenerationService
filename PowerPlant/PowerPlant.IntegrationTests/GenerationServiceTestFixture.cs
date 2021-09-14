using Microsoft.AspNetCore.Hosting;
using System;
using System.Net.Http;
using Microsoft.AspNetCore.TestHost;

namespace PowerPlant.IntegrationTests
{
    public class GenerationServiceTestFixture : IDisposable
    {
        private readonly TestServer _apiTestServer;

        public GenerationServiceTestFixture()
        {
            var builder = new WebHostBuilder()
                .UseStartup<GenerationService.Startup>();
            _apiTestServer = new TestServer(builder);

            Client = _apiTestServer.CreateClient();
            Client.BaseAddress = new Uri("http://localhost:5000/api");
        }

        public HttpClient Client { get; }

        public void Dispose()
        {
            Client.Dispose();
            _apiTestServer.Dispose();
        }
    }
}
