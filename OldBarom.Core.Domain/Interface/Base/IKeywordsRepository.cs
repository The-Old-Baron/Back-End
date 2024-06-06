using OldBarom.Core.Domain.Model.Base;

namespace OldBarom.Core.Domain.Interface.Base
{
    public interface IKeywordsRepository
    {
        Task<IEnumerable<Keywords>> GetKeywords();
        Task<Keywords> GetKeyword(int id);
        Task AddKeyword(Keywords keyword);
        Task UpdateKeyword(Keywords keyword);
        Task DeleteKeyword(int id);
    }
}
