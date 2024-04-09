using OldBarom.Core.Application.DTOs.MyLinkList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldBarom.Core.Application.Interfaces.MyLinkList
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDTO>> GetCategories();
        Task<CategoryDTO> GetCategoryByID(int id);
        Task Add(CategoryDTO category);
        Task Update(CategoryDTO category);
        Task Delete(int id);
    }
}
