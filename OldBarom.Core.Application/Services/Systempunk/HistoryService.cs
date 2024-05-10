
using AutoMapper;
using OldBarom.Core.Application.DTOs.Systempunk;
using OldBarom.Core.Application.Interfaces.Systempunk;
using OldBarom.Core.Domain.Entities.Systempunk;
using OldBarom.Core.Domain.Interfaces;

namespace OldBarom.Core.Application.Services.Systempunk
{
    public class HistoryService : IHistoryService
    {
        private IHistoryRepository _historyService;
        private readonly IMapper _mapper;
        public HistoryService(IHistoryRepository historyService, IMapper mapper)
        {
            _historyService = historyService;
            _mapper = mapper;
        }

        public async Task Add(HistoryDTO historyDTO)
        {
            var historyEntity = _mapper.Map<History>(historyDTO);
            await _historyService.CreateAsync(historyEntity);
        }

        public async Task Delete(int id)
        {
            await _historyService.DeleteAsync(id);
        }

        public async Task<IEnumerable<HistoryDTO>> GetHistories()
        {
            var historiesEntity = await _historyService.GetHistoriesAsync();
            return _mapper.Map<IEnumerable<HistoryDTO>>(historiesEntity);
        }

        public async Task<HistoryDTO> GetHistory(int id)
        {
            var historyEntity = await _historyService.GetHistoryByID(id);
            return _mapper.Map<HistoryDTO>(historyEntity);
        }

        public async Task Update(HistoryDTO historyDTO)
        {
            var historyEntity = _mapper.Map<History>(historyDTO);
            await _historyService.UpdateAsync(historyEntity);
        }
    }
}
