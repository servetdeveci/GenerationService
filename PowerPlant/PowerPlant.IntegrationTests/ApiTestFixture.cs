using Microsoft.AspNetCore.Hosting;
using System;
using System.Net.Http;
using Microsoft.AspNetCore.TestHost;

namespace PowerPlant.IntegrationTests
{
    public class ApiTestFixture : IDisposable
    {
        private readonly TestServer _apiTestServer;

        public ApiTestFixture()
        {
            var builder = new WebHostBuilder()
                .UseStartup<API.Startup>();
            _apiTestServer = new TestServer(builder);

            Client = _apiTestServer.CreateClient();
            Client.BaseAddress = new Uri("http://localhost");
        }

        public HttpClient Client { get; }

        public void Dispose()
        {
            Client.Dispose();
            _apiTestServer.Dispose();
        }
    }
}
