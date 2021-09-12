using PowerPlant.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PowerPlant.Services.Services
{
    public interface IPowerPlantDefService
    {
        Task<List<PowerPlantDef>> GetAll();
        Task<PowerPlantDef> Find(string id);
        Task<int> Add(PowerPlantDef ppd);
        Task<int> Update(string id, string name);
        Task<int> Delete(string id);
    }
}
