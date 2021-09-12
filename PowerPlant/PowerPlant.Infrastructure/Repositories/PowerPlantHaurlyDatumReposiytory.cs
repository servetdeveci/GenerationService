using PowerPlant.Domain.Entities;
using PowerPlant.Domain.EntityInterfaces;
using PowerPlant.Infrastructure;

namespace PowerPlant.Domain
{
    public class PowerPlantHaurlyDatumReposiytory : AppRepository<PowerPlantHourlyDatum>, IPowerPlantHourlyDatumRepository
    {
        public PowerPlantHaurlyDatumReposiytory(AppDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}
