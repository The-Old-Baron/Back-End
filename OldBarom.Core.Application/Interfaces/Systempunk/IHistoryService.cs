using OldBarom.Core.Application.DTOs.Systempunk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldBarom.Core.Application.Interfaces.Systempunk
{
    public interface IHistoryService
    {
        Task<IEnumerable<HistoryDTO>> GetHistories();
        Task<HistoryDTO> GetHistory(int id);
        Task Add(HistoryDTO historyDTO);
        Task Update(HistoryDTO historyDTO);
        Task Delete(int id);
    }
}
