using Crm.Dtos;
using Crm.Dtos.Master;
using Crm.Entities;
using Crm.Infrastructure.Repositories;
using Crm.Utilities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crm.DataLayer.Repositories
{
    public class MasterRepository : IMasterRepository
    {
        private readonly DataContext _dataContext;

        public MasterRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        /*public async Task<IEnumerable<CountryDto>> GetCountrySelectItemsAsync()
        {
            return await _dataContext.Countries
                .AsNoTracking()
                .Where(x => x.Id != 0)
                .OrderBy(x => x.CountryName)
                .Select(x => new CountryDto
                {
                    KeyInt = x.Id,
                    Value = x.CountryName
                }).ToListAsync();
        }*/
        public async Task<List<CountryDto>> GetCountryDetails()
        {
            return await (from c in _dataContext.Countries
                          select new CountryDto
                          {
                              Id = c.Id,
                              CountryName = c.CountryName
                              
                          })
                      .AsNoTracking().ToListAsync();
        }
        public async Task<List<StateDto>>GetDetailAsync(int id)
        {
            return await (from s in _dataContext.States
                          join c in _dataContext.Countries on s.CountryId equals c.Id
                          where s.CountryId == id
                          select new StateDto
                          {
                              Id = s.Id,
                              StateName = s.StateName,
                              CountryId = s.CountryId
                          })
                      .AsNoTracking().ToListAsync();

        }
        public async Task<List<CityDto>> GetCityDetails(int id)
        {
            return await (from s in _dataContext.Cities
                          join c in _dataContext.States on s.StateId equals c.Id
                          where s.StateId == id
                          select new CityDto
                          {
                              Id = s.Id,
                              CityName = s.CityName,
                              StateId = s.StateId
                          })
                      .AsNoTracking().ToListAsync();
        }

    }
}
