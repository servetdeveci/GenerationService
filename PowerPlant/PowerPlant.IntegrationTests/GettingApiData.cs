﻿using Newtonsoft.Json;
using PowerPlant.Domain.Entities;
using System;
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
            var body = response.Content.ReadAsStringAsync().Result;
            var pps = JsonConvert.DeserializeObject<List<PowerPlantDef>>(body);

            // kontrol et
            Assert.NotNull(pps);
        }

        [Fact]
        public async Task Challenge_Get_Power_Plants_DataTables()
        {
            // Ayarla
            var request = new HttpRequestMessage(HttpMethod.Get, ":4200/#/home");

            // Cagir
            var response = await _client.SendAsync(request);
            var body = response.Content.ReadAsStringAsync().Result;
            
            Assert.Contains("dataTables_paginate paging_full_numbers", body);
        }
    }
}