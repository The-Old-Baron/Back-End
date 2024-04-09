using Microsoft.EntityFrameworkCore;
using OldBarom.Core.Domain.Entities.LinkList;
using OldBarom.Core.Domain.Repository.MySkinList;
using OldBarom.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldBarom.Infra.Data.Repository.MyLinkList
{
    public class CategoryRepository : ICategoryRepository
    {
        private ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Add(Categories entity)
        {
           if(entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _context.Categories.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Categories entity)
        {
            if(entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _context.Categories.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Categories>> GetAll()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Categories> GetByID(string guid)
        {
            if(guid == null)
            {
                throw new ArgumentNullException("guid");
            }
            if(int.TryParse(guid, out int categoryGuid))
            {
                return await _context.Categories.FirstOrDefaultAsync(x => x.Id == categoryGuid);
            }
            return null;
        }

        public async Task Update(Categories entity)
        {
            if(entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _context.Categories.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
