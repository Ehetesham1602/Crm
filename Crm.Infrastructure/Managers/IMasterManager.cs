using Crm.Dtos.Master;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Crm.Infrastructure.Managers
{
    public interface IMasterManager
    {
        //Task<IEnumerable<SelectMasterListDto>> GetCountrySelectItemsAsync();
        Task<List<CountryDto>> GetCountryDetails();
        Task<List<StateDto>> GetDetailAsync(int id);
        Task<List<CityDto>> GetCityDetails(int id);
    }
}
