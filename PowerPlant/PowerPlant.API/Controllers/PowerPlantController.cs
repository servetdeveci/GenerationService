using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PowerPlant.Domain.Entities;
using PowerPlant.Services.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PowerPlant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("allowAll")]

    public class PowerPlantController : ControllerBase
    {
        private readonly IPowerPlantDefService _powerPlantService;

        public PowerPlantController(IPowerPlantDefService powerPlantService)
        {
            _powerPlantService = powerPlantService;
        }

        // GET: api/<PowerPlantController>
        [HttpGet]
        public Task<List<PowerPlantDef>> Get()
        {
            return _powerPlantService.GetAll();
        }

        // GET api/<PowerPlantController>/5
        [HttpGet("{id}")]
        public async Task<PowerPlantDef> Get(string id)
        {
            return await _powerPlantService.Find(id);
        }

        // POST api/<PowerPlantController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<int> Post([FromBody] PowerPlantDef ppd)
        {
            return await _powerPlantService.Add(ppd);
        }

        // PUT api/<PowerPlantController>/5
        [HttpPut("{id}")]
        public async Task<int> Put(string id, [FromBody] PowerPlantDef powerPlant)
        {
            return await _powerPlantService.Update(id, powerPlant.WebId);
        }

        // DELETE api/<PowerPlantController>/5
        [HttpDelete("{id}")]
        public async Task<int> Delete(string id)
        {
            return await _powerPlantService.Delete(id);
        }
    }
}
