using OldBarom.Core.Domain.Entities.Systempunk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldBarom.Core.Domain.Interfaces
{
    public interface IHistoryRepository
    {
        Task<IEnumerable<History>> GetHistoriesAsync();
        Task<History> GetHistoryByID(int id);
        Task<History> CreateAsync(History history);
        Task<History> UpdateAsync(History history);
        Task<History> DeleteAsync(History history);
        Task<History> DeleteAsync(int id);
    }
}
