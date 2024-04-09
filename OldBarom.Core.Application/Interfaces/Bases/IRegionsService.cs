using OldBarom.Core.Application.DTOs.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldBarom.Core.Application.Interfaces.Bases
{
    public interface IRegionsService
    {
        Task<IEnumerable<RegionsDTO>> GetRegions();
        Task<RegionsDTO> GetRegion(int id);
        Task<RegionsDTO> AddRegion(RegionsDTO region);
        Task<RegionsDTO> UpdateRegion(RegionsDTO region);
        Task<RegionsDTO> DeleteRegion(int id);
    }
}
