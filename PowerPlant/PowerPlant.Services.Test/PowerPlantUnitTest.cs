using Microsoft.Extensions.DependencyInjection;
using PowerPlant.Domain.Entities;
using PowerPlant.Infrastructure.Extensions;
using PowerPlant.Services.Services;
using System;
using System.Threading;
using Xunit;

namespace PowerPlant.UnitTest
{
    public class PowerPlantUnitTest
    {

        private readonly IServiceProvider _serviceProvider;
        private readonly IServiceCollection services = new ServiceCollection();
        private readonly IPowerPlantDefService _powerPlantDefService;
        private readonly IPowerPlantDatumService _powerPlantDatumService;
        private readonly string connectionString = "Host=localhost;Port=5432;Database=PowerPlant;Username=postgres;Password=pass";
        // burada servisleri DI yöntemi ile initialize ediyoruz. Normal veritabaný kullanýlýyor.
        // vakit kalýrsa Moq ile deneyeceðim.
        public PowerPlantUnitTest()
        {
            services.AddDatabase(connectionString).AddRepositories().AddEntityServices();
            _serviceProvider = services.BuildServiceProvider();
            _powerPlantDefService = _serviceProvider.GetRequiredService<IPowerPlantDefService>();
            _powerPlantDatumService = _serviceProvider.GetRequiredService<IPowerPlantDatumService>();
        }

        [Fact]
        public void Adding_PowerPlant()
        {
            var obj = new PowerPlantDef
            {
                Id = "sample_id1",
                WebId = "sample_name"
            };
            var result = _powerPlantDefService.Add(obj).Result;
            Assert.Equal(1, result);
        }
        [Fact]
        public void Adding_PowerPlantDatum()
        {
            var obj = new PowerPlantHourlyDatum
            {
                Id = Guid.NewGuid().ToString(),
                PowerPlantId = "sample_id1",
                CreatedDate = DateTime.Now,
                Value = "10"
            };
            var result = _powerPlantDatumService.Add(obj).Result;
            Assert.Equal(1, result);
        }
        [Fact]
        public void Getting_PowerPlant_All_Data()
        {
            var result = _powerPlantDatumService.GetAll("id").Result;
            Assert.NotNull(result);
        }
        [Fact]
        public void Getting_AllPowerPlant()
        {
            var result = _powerPlantDefService.GetAll().Result;
            Assert.NotNull(result);
        }
        [Fact]
        public void Getting_PowerPlant()
        {
            var result = _powerPlantDefService.Find("sample_id1");
            Assert.NotNull(result);
        }
        [Fact]
        public void Update_PowerPlant()
        {
            var result = _powerPlantDefService.Update("sample_id1", "new_sample_name").Result;
            var obj = _powerPlantDefService.Find("sample_id1").Result;
            Assert.Equal("new_sample_name", obj.WebId);
        }
        [Fact]
        public void Delete_PowerPlant()
        {
            var result = _powerPlantDefService.Delete("sample_id1").Result;
            Assert.Equal(1, result);
        }

    }
}
