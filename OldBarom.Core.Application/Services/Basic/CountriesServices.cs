using AutoMapper;
using OldBarom.Core.Application.DTOs.Bases;
using OldBarom.Core.Application.Interfaces.Bases;
using OldBarom.Core.Domain.Repository.Basic;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OldBarom.Core.Application.Services.Basic
{
    public class CountriesServices : ICountriesService
    {
        private readonly ICountriesRepository _countryRepository;
        private readonly IMapper _mapper;

        public CountriesServices(ICountriesRepository countryRepository, IMapper mapper)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
        }

        public async Task Add(CountriesDTO country)
        {
            var countryEntity = _mapper.Map<OldBarom.Core.Domain.Entities.Basic.Countries>(country);
            await _countryRepository.AddCountry(countryEntity);
            country.CountryID = countryEntity.Id;
        }

        public async Task Delete(int id)
        {
            var country = await _countryRepository.GetCountryById(id);
            if (country == null)
            {
                throw new Exception("Country not found");
            }
            await _countryRepository.DeleteCountry(id);
        }

        public async Task<IEnumerable<CountriesDTO>> GetCountries()
        {
            var countries = await _countryRepository.GetCountries();
            return _mapper.Map<IEnumerable<CountriesDTO>>(countries);
        }

        public async Task<CountriesDTO> GetCountryByID(int id)
        {
            var country = await _countryRepository.GetCountryById(id);
            return _mapper.Map<CountriesDTO>(country);
        }

        public async Task<CountriesDTO> GetCountryByName(string name)
        {
            var country = await _countryRepository.GetCountryByName(name);
            return _mapper.Map<CountriesDTO>(country);
        }

        public async Task Update(CountriesDTO country)
        {
            var countryEntity = _mapper.Map<OldBarom.Core.Domain.Entities.Basic.Countries>(country);
            await _countryRepository.UpdateCountry(countryEntity);
        }
    }
}
