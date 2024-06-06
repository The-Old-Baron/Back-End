using AutoMapper;
using OldBarom.Core.Application.Interface.Systempunk;
using OldBarom.Core.Domain.Interface.Systempunk;
using OldBarom.Core.Domain.Model.Systempunk;

namespace OldBarom.Core.Application.Services.Systempunk
{
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
            return await _historyRepository.AddHistory(historyEntity);
        }

        public async Task<History> DeleteHistoryAsync(History history)
        {
            var historyEntity = _mapper.Map<History>(history);
            return await _historyRepository.DeleteHistory(historyEntity.Id);
        }

        public async Task<History> DeleteHistoryAsync(Guid id)
        {
            return await _historyRepository.DeleteHistory(id);
        }

        public async Task<IEnumerable<History>> GetHistoryAsync(string name)
        {
            return await _historyRepository.GetHistoryByName(name);
        }

        public async Task<History> GetHistoryAsync(Guid id)
        {
            return await _historyRepository.GetHistory(id);
        }

        public Task<IEnumerable<History>> GetHistoryAsync()
        {
            return _historyRepository.GetHistories();
        }

        public async Task<History> UpdateHistoryAsync(Guid id, History history)
        {
            var historyEntity = _mapper.Map<History>(history);
            return await _historyRepository.UpdateHistory(id, historyEntity);
        }
    }
}
