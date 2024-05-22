using OldBarom.Core.Domain.Model.Systempunk;

namespace OldBarom.Core.Domain.Interface.Systempunk
{
    public interface IHistoryRepository
    {
        Task<IEnumerable<History>> GetHistories();
        Task<History> GetHistory(Guid id);
        Task AddHistory(History history);
        Task UpdateHistory(History history);
        Task DeleteHistory(Guid id);
    }
}