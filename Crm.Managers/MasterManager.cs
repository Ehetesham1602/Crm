using Crm.Dtos;
using Crm.Dtos.Master;
using Crm.Infrastructure.DataLayer;
using Crm.Infrastructure.Managers;
using Crm.Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace Crm.Managers
{
    public class MasterManager : IMasterManager
    {
        private readonly IMasterRepository _masterRepository;
        private readonly IUnitOfWork _unitOfWork;

        public MasterManager(IMasterRepository repository, IUnitOfWork unitOfWork)
        {
            _masterRepository = repository;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<SelectMasterListDto>> GetCountrySelectItemsAsync()
        {
            return await _masterRepository.GetCountrySelectItemsAsync();
        }
        public async Task<List<StateDto>> GetDetailAsync(int id)
        {
            return await _masterRepository.GetDetailAsync(id);
        }
        public async Task<List<CityDto>> GetCityDetails(int id)
        {
            return await _masterRepository.GetCityDetails(id);
        }
    }
}
