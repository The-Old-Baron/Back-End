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
    public class CountriesRepository : ICountriesRepository
    {
        private readonly ApplicationDbContext _context;
        public CountriesRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Add(Countries entity)
        {
            if(entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            _context.Countries.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Countries entity)
        {
            if(entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            _context.Countries.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Countries>> GetAll()
        {
            return await _context.Countries.ToListAsync();
        }

        public Task<Countries> GetByID(string guid)
        {
            if(guid == null)
            {
                throw new ArgumentNullException(nameof(guid));
            }
            if(int.TryParse(guid, out int countryGuid))
            {
                return _context.Countries.FirstOrDefaultAsync(c => c.Id == countryGuid);
            }
            return null;
        }

        public async Task Update(Countries entity)
        {
            if(entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            _context.Countries.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
