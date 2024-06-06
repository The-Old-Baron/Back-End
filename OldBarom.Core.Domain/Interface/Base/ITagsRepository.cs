using OldBarom.Core.Domain.Model.Base;

namespace OldBarom.Core.Domain.Interface.Base
{
    public interface ITagsRepository
    {
        Task<IEnumerable<Tags>> GetTags();
        Task<Tags> GetTag(int id);
        Task AddTag(Tags tag);
        Task UpdateTag(Tags tag);
        Task DeleteTag(int id);
    }
}
