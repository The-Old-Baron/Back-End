using OldBarom.Core.Domain.Model.Systempunk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldBarom.Core.Domain.Interface.Systempunk
{
    public interface IHistoryRepository
    {
        Task<IEnumerable<History>> GetHistories();
        Task<History> GetHistory(Guid id);
        Task<IEnumerable<History>> GetHistoryByName(string name);
        Task<History> AddHistory(History history);
        Task<History> UpdateHistory(Guid id, History history);
        Task<History> DeleteHistory(Guid id);
    }
}
