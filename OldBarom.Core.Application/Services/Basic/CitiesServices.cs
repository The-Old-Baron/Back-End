using AutoMapper;
using OldBarom.Core.Application.DTOs.Bases;
using OldBarom.Core.Application.Interfaces.Bases;
using OldBarom.Core.Domain.Repository.Basic;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OldBarom.Core.Application.Services.Basic
{
    public class CitiesServices : ICitiesService
    {
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;

        public CitiesServices(ICityRepository cityRepository, IMapper mapper)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
        }

        public async Task Add(CitiesDTO city)
        {
            var cityEntity = _mapper.Map<OldBarom.Core.Domain.Entities.Basic.Cities>(city);
            await _cityRepository.AddCity(cityEntity);
            city.CityID = cityEntity.Id;
        }

        public async Task Delete(int id)
        {
            await _cityRepository.DeleteCity(id);
        }

        public async Task<IEnumerable<CitiesDTO>> GetCities()
        {
            var cities = await _cityRepository.GetCities();
            return _mapper.Map<IEnumerable<CitiesDTO>>(cities);
        }

        public async Task<CitiesDTO> GetCityByID(int id)
        {
            var city = await _cityRepository.GetCityById(id);
            return _mapper.Map<CitiesDTO>(city);
        }

        public async Task<CitiesDTO> GetCityByName(string name)
        {
            var city = await _cityRepository.GetCityByName(name);
            return _mapper.Map<CitiesDTO>(city);
        }

        public async Task Update(CitiesDTO city)
        {
            var cityEntity = _mapper.Map<OldBarom.Core.Domain.Entities.Basic.Cities>(city);
            await _cityRepository.UpdateCity(cityEntity);
        }
    }
}
