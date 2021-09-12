using PowerPlant.Domain.Entities;
using PowerPlant.Domain.EntityInterfaces;
using PowerPlant.Infrastructure;

namespace PowerPlant.Domain
{
    public class PowerPlantDefRepository : AppRepository<PowerPlantDef>,IPowerPlantDefRepository
    {
        public PowerPlantDefRepository(AppDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}
