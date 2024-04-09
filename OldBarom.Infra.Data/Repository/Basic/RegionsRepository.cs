using Microsoft.EntityFrameworkCore;
using OldBarom.Core.Domain.Entities.Basic;
using OldBarom.Core.Domain.Repository.Basic;
using OldBarom.Infra.Data.Context;

namespace OldBarom.Infra.Data.Repository.Basic
{
    public class RegionsRepository : IRegionsRepository
    {
        public ApplicationDbContext _context;
        public RegionsRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Add(Regions entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _context.Regions.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Regions entity)
        {
            if(entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _context.Regions.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Regions>> GetAll()
        {
            return await _context.Regions.ToListAsync();
        }

        public async Task<Regions> GetByID(string guid)
        {
            if(guid == null)
            {
                throw new ArgumentNullException("guid");
            }
            if(int.TryParse(guid, out int regionGuid))
            {
                return await _context.Regions.FirstOrDefaultAsync(x => x.Id == regionGuid);
            }
            return null;
        }

        public Task Update(Regions entity)
        {
            throw new NotImplementedException();
        }
    }
}
