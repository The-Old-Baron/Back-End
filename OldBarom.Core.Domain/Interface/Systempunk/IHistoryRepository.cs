using OldBarom.Core.Domain.Model.Systempunk;

namespace OldBarom.Core.Domain.Interface.Systempunk
{
    public interface IHistoryRepository
    {
        Task<IEnumerable<History>> GetHistories();
        Task<History> GetHistory(Guid id);
        Task<History> AddHistory(History history);
        Task<History> UpdateHistory(Guid id, History history);
        Task<History> DeleteHistory(Guid id);
    }
}