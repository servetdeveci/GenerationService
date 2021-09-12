using PowerPlant.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PowerPlant.Services.Services
{
    public interface IPowerPlantDatumService
    {
        Task<List<PowerPlantHourlyDatum>> GetAll(string id);
        Task<PowerPlantHourlyDatum> Find(string id);
        Task<int> Add(PowerPlantHourlyDatum ppd);
        Task<int> Delete(string id);
    }
}
