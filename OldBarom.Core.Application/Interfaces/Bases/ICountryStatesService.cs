using OldBarom.Core.Application.DTOs.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldBarom.Core.Application.Interfaces.Bases
{
    public interface ICountryStatesService
    {
        Task<IEnumerable<CountryStatesDTO>> GetCountryStates();
        Task<CountryStatesDTO> GetCountryStateByID(int id);
        Task<CountryStatesDTO> GetCountryStateByName(string name);
        Task Add(CountryStatesDTO countryState);
        Task Update(CountryStatesDTO countryState);
        Task Delete(int id);

    }
}
