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
    public class PowerPlantDefManager : IPowerPlantDefService
    {
        private readonly IPowerPlantDefRepository _powerPlantDefRepository;
        private readonly IPowerPlantHourlyDatumRepository _powerPlantHourlyDatumRepository;
        private readonly IAppUnitOfWork _unitOfWork;

        public PowerPlantDefManager(IPowerPlantDefRepository powerPlantDefRepository, IPowerPlantHourlyDatumRepository powerPlantHourlyDatumRepository, IAppUnitOfWork unitOfWork)
        {
            _powerPlantDefRepository = powerPlantDefRepository;
            _powerPlantHourlyDatumRepository = powerPlantHourlyDatumRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<List<PowerPlantDef>> GetAll()
        {
            return await _powerPlantDefRepository.GetAllAsync();
        }
        public async Task<PowerPlantDef> Find(string id)
        {
            return await _powerPlantDefRepository.GetAsync(m => m.Id == id);
        }
        public async Task<int> Update(string id, string name)
        {
            var pp = _powerPlantDefRepository.Get(m => m.Id.Equals(id));
            pp.WebId = name;
            await _powerPlantDefRepository.UpdateAsync(pp);
            return await _unitOfWork.CommitAsync();

        }
        public async Task<int> Add(PowerPlantDef powerPlantDef)
        {
            powerPlantDef.Id = Guid.NewGuid().ToString();
            await _powerPlantDefRepository.AddAsync(powerPlantDef);
            return await _unitOfWork.CommitAsync();
        }
        public Task<int> Delete(string id)
        {
            _powerPlantDefRepository.Delete(Find(id).Result);
            return _unitOfWork.CommitAsync();

        }
    }
}
