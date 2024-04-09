using OldBarom.Core.Application.DTOs.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldBarom.Core.Application.Interfaces.Bases
{
    public interface ICitiesService
    {
        Task<IEnumerable<CitiesDTO>> GetCities();
        Task<CitiesDTO> GetCityByID(int id);
        Task<CitiesDTO> GetCityByName(string name);
        Task Add(CitiesDTO city);
        Task Update(CitiesDTO city);
        Task Delete(int id);
    }
}
