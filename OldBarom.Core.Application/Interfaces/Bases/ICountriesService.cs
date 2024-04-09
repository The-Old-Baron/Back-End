using OldBarom.Core.Application.DTOs.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldBarom.Core.Application.Interfaces.Bases
{
    public interface ICountriesService
    {
        Task<IEnumerable<CountriesDTO>> GetCountries();
        Task<CountriesDTO> GetCountryByID(int id);
        Task<CountriesDTO> GetCountryByName(string name);
        Task Add(CountriesDTO country);
        Task Update(CountriesDTO country);
        Task Delete(int id);
    }
}
