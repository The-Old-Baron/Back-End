using AutoMapper;
using OldBarom.Core.Application.DTOs.Bases;
using OldBarom.Core.Application.Interfaces.Bases;
using OldBarom.Core.Domain.Repository.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldBarom.Core.Application.Services.Basic
{
    public class RegionsServices : IRegionsService
    {
        public IRegionsRepository _regionsRepository;
        public Mapper Mapper;
        public RegionsServices(IRegionsRepository regionsRepository, Mapper mapper)
        {
            _regionsRepository = regionsRepository;
            Mapper = mapper;
        }
        public async Task<RegionsDTO> AddRegion(RegionsDTO region)
        {
            var regionEntity = Mapper.Map<OldBarom.Core.Domain.Entities.Basic.Regions>(region);
            await _regionsRepository.AddRegion(regionEntity);
            region.RegionID = regionEntity.Id;
            return region;
        }

        public async Task<RegionsDTO> DeleteRegion(int id)
        {
            var region = await _regionsRepository.GetRegionById(id);
            if (region == null)
            {
                throw new Exception("Region not found");
            }
            await _regionsRepository.DeleteRegion(id);
            return Mapper.Map<RegionsDTO>(region);

        }

        public async Task<RegionsDTO> GetRegion(int id)
        {
            var region = await _regionsRepository.GetRegionById(id);
            return Mapper.Map<RegionsDTO>(region);
        }

        public async Task<IEnumerable<RegionsDTO>> GetRegions()
        {
            var regions = await _regionsRepository.GetRegions();
            return Mapper.Map<IEnumerable<RegionsDTO>>(regions);
        }

        public async Task<RegionsDTO> UpdateRegion(RegionsDTO region)
        {
            var regionEntity = Mapper.Map<OldBarom.Core.Domain.Entities.Basic.Regions>(region);
            await _regionsRepository.UpdateRegion(regionEntity);
            return region;
        }
    }
}
