using PowerPlant.Domain;
using PowerPlant.Domain.Entities;
using PowerPlant.Domain.EntityInterfaces;
using PowerPlant.Services.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PowerPlant.Services.Managers
{
    public class PowerPlantDatumManager : IPowerPlantDatumService
    {
        private readonly IPowerPlantHourlyDatumRepository _powerPlantHourlyDatumRepository;
        private readonly IAppUnitOfWork _unitOfWork;

        public PowerPlantDatumManager(IPowerPlantHourlyDatumRepository powerPlantHourlyDatumRepository, IAppUnitOfWork unitOfWork)
        {
            _powerPlantHourlyDatumRepository = powerPlantHourlyDatumRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<PowerPlantHourlyDatum>> GetAll(string id)
        {
            return await _powerPlantHourlyDatumRepository.GetAllAsync(m=> m.PowerPlantId.Equals(id));
        }
        public async Task<PowerPlantHourlyDatum> Find(string id)
        {
            return await _powerPlantHourlyDatumRepository.GetAsync(m => m.Id == id);
        }
     
        public async Task<int> Add(PowerPlantHourlyDatum val)
        {
            await _powerPlantHourlyDatumRepository.AddAsync(val);
            return await _unitOfWork.CommitAsync();
        }
        public Task<int> Delete(string id)
        {
            _powerPlantHourlyDatumRepository.RemoveRange(m => m.PowerPlantId == id);
            return _unitOfWork.CommitAsync();
        }

      
    }
}
