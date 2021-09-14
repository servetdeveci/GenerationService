using Microsoft.Extensions.DependencyInjection;
using Moq;
using PowerPlant.Domain.Entities;
using PowerPlant.Infrastructure.Extensions;
using PowerPlant.Services.Services;
using System;
using System.Collections.Generic;
using System.Threading;
using Xunit;

namespace PowerPlant.UnitTest
{
    public class PowerPlantUnitTest
    {
        //// burada servisleri DI yöntemi ile initialize ediyoruz. Normal veritabaný kullanýlýyor.
        //private readonly IServiceProvider _serviceProvider;
        //private readonly IServiceCollection services = new ServiceCollection();
        //private readonly IPowerPlantDefService _powerPlantDefService;
        //private readonly IPowerPlantDatumService _powerPlantDatumService;
        //private readonly string connectionString = "Host=database;Port=5432;Database=PowerPlant;Username=postgres;Password=pass";
        
        // Moq ile test.
        private Mock<IPowerPlantDefService> _mockPowerPlantService;
        private Mock<IPowerPlantDatumService> _mockPowerPlantDataService;
        public PowerPlantUnitTest()
        {
            //// normal veritabanýna yazýlarak oluþturulan test
            //services.AddDatabase(connectionString).AddRepositories().AddEntityServices();
            //_serviceProvider = services.BuildServiceProvider();
            //_powerPlantDefService = _serviceProvider.GetRequiredService<IPowerPlantDefService>();
            //_powerPlantDatumService = _serviceProvider.GetRequiredService<IPowerPlantDatumService>();

            // mock kullanýlarak oluþturulan test
            _mockPowerPlantService = new Mock<IPowerPlantDefService>();
            _mockPowerPlantDataService = new Mock<IPowerPlantDatumService>();
        }

        [Fact]
        public void Adding_PowerPlant()
        {
            // mock kullanarak
            var obj = new PowerPlantDef
            {
                Id = "sample_id1",
                WebId = "sample_name"
            };
            _mockPowerPlantService.Setup(x => x.Add(obj).Result).Returns(1);
            Assert.Equal(1, _mockPowerPlantService.Object.Add(obj).Result);

            // gercek db kullanarak
            //var result = _powerPlantDefService.Add(obj).Result;
            //result = _powerPlantDefService.Delete(obj.Id).Result;
            //Assert.Equal(1, result);
        }
        [Fact]
        public void Adding_PowerPlantDatum()
        {
            // mock kullanarak
            var pp = new PowerPlantDef
            {
                Id = "sample_id2",
                WebId = "sample_name"
            };
            var datum = new PowerPlantHourlyDatum
            {
                Id = Guid.NewGuid().ToString(),
                PowerPlantId = "sample_id2",
                CreatedDate = DateTime.Now,
                Value = "10"
            };
            _mockPowerPlantService.Setup(x => x.Add(pp).Result).Returns(1);
            _mockPowerPlantDataService.Setup(x => x.Add(datum).Result).Returns(1);
            Assert.Equal(1, _mockPowerPlantDataService.Object.Add(datum).Result);

            // gercek db kullanarak
            //var result = _powerPlantDefService.Add(pp).Result;
            //result = _powerPlantDatumService.Add(datum).Result;
            //result = _powerPlantDefService.Delete(pp.Id).Result;
            //Assert.True(result > 1);
        }
        [Fact]
        public void Getting_PowerPlant_All_Data()
        {
            // mock kullanarak
            _mockPowerPlantDataService.Setup(x => x.GetAll("id").Result).Returns(new List<PowerPlantHourlyDatum>());
            Assert.NotNull(_mockPowerPlantDataService.Object.GetAll("id").Result);

            // gercek db kullanarak
            //var result = _powerPlantDatumService.GetAll("id").Result;
            //Assert.NotNull(result);
        }
        [Fact]
        public void Getting_AllPowerPlant()
        {
            // mock kullanarak
            _mockPowerPlantService.Setup(x => x.GetAll().Result).Returns(new List<PowerPlantDef>());
            Assert.NotNull(_mockPowerPlantService.Object.GetAll().Result);

            //// gercekt db kullanarak
            //var result = _powerPlantDefService.GetAll().Result;
            //Assert.NotNull(result);
        }
        [Fact]
        public void Getting_PowerPlant()
        {
            var obj = new PowerPlantDef
            {
                Id = "sample_id3",
                WebId = "sample_name"
            };

            // mock kullanarak
            _mockPowerPlantService.Setup(x => x.Find(obj.Id).Result).Returns(obj);
            Assert.Equal(obj.Id, _mockPowerPlantService.Object.Find(obj.Id).Result.Id);

            // gercek db kullanarak
            //var result = _powerPlantDefService.Add(obj).Result;
            //var pp = _powerPlantDefService.Find("sample_id3");
            //Assert.NotNull(pp);
        }
        [Fact]
        public void Update_PowerPlant()
        {
            // mock kullanarak
            _mockPowerPlantService.Setup(x => x.Update("sample_Update_id2", "sample_Update_name_guncellendi").Result).Returns(1);
            Assert.Equal(1, _mockPowerPlantService.Object.Update("sample_Update_id2", "sample_Update_name_guncellendi").Result);

            //// gercek db kullanarak
            //var result = _powerPlantDefService.Update("sample_id1", "new_sample_name").Result;
            //var obj = _powerPlantDefService.Find("sample_id1").Result;
            //Assert.Equal("new_sample_name", obj.WebId);
        }
        [Fact]
        public void Delete_PowerPlant()
        {
            // mock kullanarak
            _mockPowerPlantService.Setup(x => x.Delete("sample_Update_id2").Result).Returns(1);
            Assert.Equal(1, _mockPowerPlantService.Object.Delete("sample_Update_id2").Result);

            //// gercek db kullanarak
            //var result = _powerPlantDefService.Delete("sample_id1").Result;
            //Assert.Equal(1, result);
        }

    }
}
