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
    public class LinkRepository : ILinkRepository
    {
        public ApplicationDbContext _context;
        public LinkRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Add(Links entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _context.Links.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Links entity)
        {
            if(entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _context.Links.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Links>> GetAll()
        {
            return await _context.Links.ToListAsync();
        }

        public async Task<Links> GetByID(string guid)
        {
            if(guid == null)
            {
                throw new ArgumentNullException("guid");
            }
            if(int.TryParse(guid, out int linkGuid))
            {
                return await _context.Links.FirstOrDefaultAsync(x => x.Id == linkGuid);
            }
            return null;
        }

        public async Task Update(Links entity)
        {
            if(entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _context.Links.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
