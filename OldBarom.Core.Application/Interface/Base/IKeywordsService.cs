using OldBarom.Core.Domain.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldBarom.Core.Application.Interface.Base
{
    public interface IKeywordsService
    {
        Task<IEnumerable<Keywords>> GetAllKeywords();
        Task<Keywords> GetKeywords(int id);
        Task<Keywords> GetByID(int id);
        Task<Keywords> AddKeywords(Keywords key);
        Task<Keywords> DeleteKeywords(Keywords key);
        Task<Keywords> DeleteKeywords(int id);
        Task<Keywords> UpdateKeywords(int id, Keywords keywords);
        Task<Keywords> GetByKeyword(string keyword);
        Task<IEnumerable<Keywords>> GetByType(int keywordType);
    }
}
