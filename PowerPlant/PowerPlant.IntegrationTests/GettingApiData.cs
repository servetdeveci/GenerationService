using Newtonsoft.Json;
using PowerPlant.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
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

        [Fact]
        public async Task Challenge_Get_Power_Plants_DataTables()
        {
            Thread.Sleep(5000);
            _client.BaseAddress = new Uri("http://localhost:4200");
            var request = new HttpRequestMessage(HttpMethod.Get, "/home");

            var response = await _client.SendAsync(request);
            var body = response.Content.ReadAsStringAsync().Result;
            
            Assert.Contains("dataTables_paginate paging_full_numbers", body);
        }
    }
}