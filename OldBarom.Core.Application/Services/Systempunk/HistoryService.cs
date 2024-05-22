using OldBarom.Core.Application.DTOs.Systempunk;
using OldBarom.Core.Domain.Interface.Systempunk;

namespace OldBarom.Core.Application.Serivces.Systempunk{
    public class HistoryService : IHistoryService{
        private readonly IHistoryRepository _historyRepository;
        private readonly IMapper _mapper;

        public HistoryService(IHistoryRepository historyRepository, IMapper mapper){
            _historyRepository = historyRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<HistoryDTO>> GetHistoriesAsync(){
            var histories = await _historyRepository.GetHistoriesAsync();
            return _mapper.Map<IEnumerable<HistoryDTO>>(histories);
        }

        public async Task<HistoryDTO> GetHistoryByIdAsync(int id){
            var history = await _historyRepository.GetHistoryByIdAsync(id);
            return _mapper.Map<HistoryDTO>(history);
        }

        public async Task<HistoryDTO> CreateHistoryAsync(HistoryDTO historyDTO){
            var history = _mapper.Map<History>(historyDTO);
            history = await _historyRepository.CreateHistoryAsync(history);
            return _mapper.Map<HistoryDTO>(history);
        }

        public async Task<HistoryDTO> UpdateHistoryAsync(int id, HistoryDTO historyDTO){
            var history = _mapper.Map<History>(historyDTO);
            history = await _historyRepository.UpdateHistoryAsync(id, history);
            return _mapper.Map<HistoryDTO>(history);
        }

        public async Task<HistoryDTO> DeleteHistoryAsync(int id){
            var history = await _historyRepository.DeleteHistoryAsync(id);
            return _mapper.Map<HistoryDTO>(history);
        }
    }
}