using OldBarom.Core.Application.DTOs.Systempunk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldBarom.Core.Application.Interfaces.Systempunk
{
    public interface ITagService
    {
        Task<IEnumerable<TagDTO>> GetTags();
        Task<TagDTO> GetTagById(int id);
        Task Add(TagDTO tagDTO);
        Task Update(TagDTO tagDTO);
        Task Delete(int id);
    }
}
