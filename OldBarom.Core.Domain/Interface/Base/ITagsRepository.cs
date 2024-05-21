namespace OldBarom.Core.Domain.Interface.Systempunk
{
    public interface IHistoryRepository
    {
        Task<IEnumerable<History>> GetHistories();
        Task<History> GetHistory(int id);
        Task AddHistory(History history);
        Task UpdateHistory(History history);
        Task DeleteHistory(int id);
    }
}