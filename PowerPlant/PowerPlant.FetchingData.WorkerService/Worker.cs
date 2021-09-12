using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PowerPlant.Domain.Entities;
using PowerPlant.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PowerPlant.FetchingData.WorkerService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private HttpClient _client;
        int second, minute, hour;
        const int timeFactor = 60;
        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
            SetupTimes();
        }

        private void SetupTimes()
        {
            second = 1000;
            minute = second * timeFactor;
            hour = minute * timeFactor;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation($"***** Hourly service is started  *******", DateTimeOffset.Now);
            _client = new HttpClient();
            _client.BaseAddress = new Uri("http://webapi/api/");
            return base.StartAsync(cancellationToken);
        }


        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    var response = _client.GetAsync($"powerplant").Result;
                    List<PowerPlantDef> list = new List<PowerPlantDef>();

                    var responseBody = response.Content.ReadAsStringAsync().Result;
                    list = JsonConvert.DeserializeObject<List<PowerPlantDef>>(responseBody);
                    foreach (var item in list)
                    {
                        _logger.LogInformation($"webId: {item.WebId} verileri çekiliyor...");
                        var dateTime = DateTime.Now;
                        var endTime = dateTime.ToString();
                        var startTime = dateTime.AddDays(-1).ToString();
                        response = _client.GetAsync($"generationservice/get?webId={item.WebId}&startTime={startTime}&endTime={endTime}").Result;    
                        responseBody = response.Content.ReadAsStringAsync().Result;
                        var usages = JsonConvert.DeserializeObject<ApiResponse<TimedValues>>(responseBody);

                        if (usages.Status)
                        {
                            foreach (var value in usages.Data.Items)
                            {
                                var datum = new PowerPlantHourlyDatum
                                {
                                    Id = Guid.NewGuid().ToString(),
                                    PowerPlantId = item.Id,
                                    Value =JsonConvert.SerializeObject(value.Value),
                                    CreatedDate = value.Timestamp
                                };
                                response = _client.PostAsync($"PowerPlantData", new StringContent(JsonConvert.SerializeObject(datum), Encoding.UTF8, "application/json")).Result;
                                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                                {
                                    if (response.Content.ReadAsStringAsync().Result == "1")
                                    {
                                        _logger.LogInformation($"Veri eklendi");
                                    }
                                    else
                                    {
                                        _logger.LogError($"Veri eklenemedi: {response.StatusCode}");

                                    }
                                }
                                else
                                {
                                    _logger.LogError($"data ekleme servisi hatası: {response.StatusCode}");
                                }
                            }
                        }
                        else
                        {
                            _logger.LogError($"Serviste random veri oluşturulurken hata gercekleşti: {usages.StatusMessage}");
                        }
                    }

                }
                catch (Exception ex)
                {
                    _logger.LogCritical($"ex : {ex}");
                }

                await Task.Delay(minute/6, stoppingToken);
            }
        }



        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogDebug($"***** Hourly service is stopped  *******", DateTimeOffset.Now);
            base.Dispose();
            return base.StopAsync(cancellationToken);
        }

    }
}
