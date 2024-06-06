using OldBarom.Core.Domain.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
