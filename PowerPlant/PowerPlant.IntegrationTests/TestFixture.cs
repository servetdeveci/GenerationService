using Microsoft.AspNetCore.Hosting;
using System;
using System.Net.Http;
using Microsoft.AspNetCore.TestHost;

namespace PowerPlant.IntegrationTests
{
    public class TestFixture : IDisposable
    {
        private readonly TestServer _server;

        public TestFixture()
        {
            var builder = new WebHostBuilder()
                .UseStartup<API.Startup>()
                .ConfigureAppConfiguration((context, configBuilder) =>
                {
                });
            _server = new TestServer(builder);

            Client = _server.CreateClient();
            Client.BaseAddress = new Uri("http://localhost");
        }

        public HttpClient Client { get; }

        public void Dispose()
        {
            Client.Dispose();
            _server.Dispose();
        }
    }
}
