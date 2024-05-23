using OldBarom.Core.Domain.Model.Base;

namespace OldBarom.Core.Application.Interface.Base
{
    public interface IKeywordsService
    {
        Task<IEnumerable<Keywords>> GetAllKeywords();
        Task<Keywords> GetKeywords(Guid id);
        Task<Keywords> AddKeywords(Keywords key);
        Task<Keywords> DeleteKeywords(Keywords key);
        Task<Keywords> DeleteKeywords(Guid id);
        Task<Keywords> UpdateKeywords(Guid id, Keywords keywords);
    }
}
