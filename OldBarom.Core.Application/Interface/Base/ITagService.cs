using OldBarom.Core.Domain.Model.Base;

namespace OldBarom.Core.Application.Interface.Base
{
    public interface ITagService
    {
        Task<IEnumerable<Tags>> GetAllTags();
        Task<Tags> GetTagByID(Guid guid);
        Task<Tags> GetByName(string name);
        Task<Tags> AddTag(Tags tags);
        Task<Tags> RemoveTag(Tags tag);
        Task<Tags> RemoveTag(Guid id);

    }
}
