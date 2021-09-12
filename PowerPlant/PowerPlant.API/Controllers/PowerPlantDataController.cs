using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using PowerPlant.Domain.Entities;
using PowerPlant.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PowerPlant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("allowAll")]
    public class PowerPlantDataController : ControllerBase
    {
        private readonly IPowerPlantDatumService _powerPlantDatumService;

        public PowerPlantDataController(IPowerPlantDatumService powerPlantService)
        {
            _powerPlantDatumService = powerPlantService;
        }


        // GET: api/<PowerPlantData>
        [HttpGet("{id}")]
        public async Task<List<PowerPlantHourlyDatum>> Get(string id)
        {
            return await _powerPlantDatumService.GetAll(id);
        }

        // POST api/<PowerPlantData>
        [HttpPost]
        public async Task<int> Post([FromBody] PowerPlantHourlyDatum powerPlantHourlyDatum)
        {
           return await _powerPlantDatumService.Add(powerPlantHourlyDatum);
        }

        // PUT api/<PowerPlantData>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/<PowerPlantData>/5
        [HttpDelete("{id}")]
        public async Task<int> Delete(string id)
        {
            return await _powerPlantDatumService.Delete(id);
        }
    }
}
