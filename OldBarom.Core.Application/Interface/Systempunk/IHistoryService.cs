using OldBarom.Core.Domain.Model.Systempunk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldBarom.Core.Application.Interface.Systempunk
{
    public interface IHistoryService
    {
        Task<IEnumerable<History>> GetHistoryAsync();
        Task<History> GetHistoryAsync(Guid id);
        Task<History> AddHistoryAsync(History history);
        Task<History> DeleteHistoryAsync(History history);
        Task<History> DeleteHistoryAsync(Guid id);
        Task<History> UpdateHistoryAsync(Guid id, History history);
    }
}
