using OldBarom.Core.Domain.Entities.Systempunk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldBarom.Core.Domain.Interfaces
{
    public interface ITagRepository
    {
        Task<IEnumerable<Tag>> GetTagsAsync();
        Task<Tag> GetByIdAsync(int? id);
        Task<Tag> CreateAsync(Tag tag);
        Task<Tag> UpdateAsync(Tag tag);
        Task<Tag> RemoveAsync(Tag tag);
        Task<Tag> RemoveAsync(int id);
    }
}
