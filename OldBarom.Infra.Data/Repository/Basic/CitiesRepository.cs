using Microsoft.EntityFrameworkCore;
using OldBarom.Core.Domain.Entities.Basic;
using OldBarom.Core.Domain.Repository.Basic;
using OldBarom.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldBarom.Infra.Data.Repository.Basic
{
    public class CitiesRepository : ICityRepository
    {
        private ApplicationDbContext _context;
        public CitiesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Add(Cities entity)
        {
            if(entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            await _context.Cities.AddAsync(entity);
        }

        public async Task Delete(Cities entity)
        {
            if(entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _context.Cities.Remove(entity);
            
        }

        public async Task<IEnumerable<Cities>> GetAll()
        {
            return await _context.Cities.ToListAsync();
        }

        public Task<Cities> GetByID(string guid)
        {
            if(guid == null)
            {
                throw new ArgumentNullException("guid");
            }
            if(int.TryParse(guid, out int result))
            {
                return _context.Cities.Where(x => x.Id == result).FirstOrDefaultAsync();
            }
            return null;
        }

        public async Task Update(Cities entity)
        {
            if(entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _context.Cities.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
