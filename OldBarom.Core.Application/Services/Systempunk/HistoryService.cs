using AutoMapper;
using OldBarom.Core.Application.DTOs.Systempunk;
using OldBarom.Core.Application.Interface;
using OldBarom.Core.Domain.Interface.Systempunk;
using OldBarom.Core.Domain.Model.Systempunk;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OldBarom.Core.Application.Serivces.Systempunk{
    public class HistoryService : IHistoryService{
        private readonly IHistoryRepository _historyRepository;
        private readonly IMapper _mapper;

        public HistoryService(IHistoryRepository historyRepository, IMapper mapper){
            _historyRepository = historyRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<HistoryDTO>> GetHistoriesAsync(){
            var histories = await _historyRepository.GetHistories();
            return _mapper.Map<IEnumerable<HistoryDTO>>(histories);
        }

        public async Task<HistoryDTO> GetHistoryByIdAsync(Guid id){
            var history = await _historyRepository.GetHistory(id);
            return _mapper.Map<HistoryDTO>(history);
        }

        public async Task<HistoryDTO> CreateHistoryAsync(HistoryDTO historyDTO){
            var history = _mapper.Map<History>(historyDTO);
            history = await _historyRepository.AddHistory(history);
            return _mapper.Map<HistoryDTO>(history);
        }

        public async Task<HistoryDTO> UpdateHistoryAsync(Guid id, HistoryDTO historyDTO){
            var history = _mapper.Map<History>(historyDTO);
            history = await _historyRepository.UpdateHistory(id, history);
            return _mapper.Map<HistoryDTO>(history);
        }

        public async Task<HistoryDTO> DeleteHistoryAsync(Guid id){
            var history = await _historyRepository.DeleteHistory(id);
            return _mapper.Map<HistoryDTO>(history);
        }
    }
}