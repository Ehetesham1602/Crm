using Crm.Dtos.Master;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Crm.Infrastructure.Repositories
{
    public interface IMasterRepository
    {
        Task<IEnumerable<SelectMasterListDto>> GetCountrySelectItemsAsync();
        Task<List<StateDto>> GetDetailAsync(int id);
        Task<List<CityDto>> GetCityDetails(int id);
    }
}
