using AutoMapper;
using OldBarom.Core.Domain.Entities.Basic;
using OldBarom.Core.Domain.Repository.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldBarom.Core.Application.Services.Basic
{
    public class CountryStatesServices : ICountryStateRepository
    {
        private readonly ICountryStateRepository _countryStateRepository;   
        private readonly IMapper _mapper;
        public CountryStatesServices(ICountryStateRepository countryStateRepository, IMapper mapper)
        {
            _countryStateRepository = countryStateRepository;
            _mapper = mapper;
        }
        public async Task<CountryStates> AddCountryState(CountryStates countryState)
        {
            var countryStateEntity = _mapper.Map<CountryStates>(countryState);
            await _countryStateRepository.Add(countryStateEntity);
            return countryStateEntity;
        }

        public async Task<CountryStates> DeleteCountryState(int id)
        {
            var countryState = await _countryStateRepository.GetByID(id);
            if (countryState == null)
            {
                throw new Exception("Country State not found");
            }
            await _countryStateRepository.Delete(id);
            return countryState;
        }

        public async Task<CountryStates> GetCountryStateById(int id)
        {
            var countryState = await _countryStateRepository.GetCountryStateById(id);
            return countryState;
        }

        public async Task<CountryStates> GetCountryStateByName(string name)
        {
            var countryState = await _countryStateRepository.GetCountryStateByName(name);
            return countryState;
        }

        public async Task<IEnumerable<CountryStates>> GetCountryStates()
        {
            var countryStates = await _countryStateRepository.GetCountryStates();
            return countryStates;
        }

        public async Task<CountryStates> UpdateCountryState(CountryStates countryState)
        {
            var countryStateEntity = _mapper.Map<CountryStates>(countryState);
            await _countryStateRepository.UpdateCountryState(countryStateEntity);
            return countryStateEntity;
        }
    }
}
