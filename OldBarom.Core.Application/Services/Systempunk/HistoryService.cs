using AutoMapper;
using OldBarom.Core.Application.DTOs.Systempunk;
using OldBarom.Core.Application.Interface.Systempunk;
using OldBarom.Core.Domain.Interface.Systempunk;
using OldBarom.Core.Domain.Model.Systempunk;

namespace OldBarom.Core.Application.Serivces.Systempunk{
    public class HistoryService : IHistoryService
    {
        private readonly IHistoryRepository _historyRepository;
        private readonly IMapper _mapper;

        public HistoryService(IHistoryRepository historyRepository, IMapper mapper)
        {
            _historyRepository = historyRepository;
            _mapper = mapper;
        }
        public async Task<History> AddHistoryAsync(History history)
        {
            var historyEntity = _mapper.Map<History>(history);
            return await _historyRepository.AddHistoryAsync(historyEntity);
        }

        public async Task<History> DeleteHistoryAsync(History history)
        {
            var historyEntity = _mapper.Map<History>(history);
            return await _historyRepository.DeleteHistoryAsync(historyEntity);
        }

        public async Task<History> DeleteHistoryAsync(Guid id)
        {
            return await _historyRepository.DeleteHistoryAsync(id);
        }

        public async Task<IEnumerable<History>> GetHistoryAsync(string name)
        {
            return await _historyRepository.GetHistoryAsync(name);
        }

        public async Task<History> GetHistoryAsync(Guid id)
        {
            return await _historyRepository.GetHistoryAsync(id);
        }

        public async Task<History> UpdateHistoryAsync(Guid id, History history)
        {
            var historyEntity = _mapper.Map<History>(history);
            return await _historyRepository.UpdateHistoryAsync(id, historyEntity);
        }
    }
}