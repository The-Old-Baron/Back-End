using OldBarom.Core.Application.DTOs.Systempunk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldBarom.Core.Application.Interface
{
    public interface IHistoryService
    {
        Task<IEnumerable<HistoryDTO>> GetHistoriesAsync();
        Task<HistoryDTO> GetHistoryByIdAsync(Guid guid);
        Task<HistoryDTO> CreateHistoryAsync(HistoryDTO historyDTO);
        Task<HistoryDTO> UpdateHistoryAsync(Guid guid, HistoryDTO historyDTO);
        Task<HistoryDTO> DeleteHistoryAsync(Guid guid);

    }
}
