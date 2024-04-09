using Microsoft.EntityFrameworkCore;
using OldBarom.Core.Domain.Entities.Basic;
using OldBarom.Core.Domain.Repository.Basic;
using OldBarom.Infra.Data.Context;

namespace OldBarom.Infra.Data.Repository.Basic
{
    public class CountryStateRepository : ICountryStateRepository
    {
        private ApplicationDbContext _context;
        public CountryStateRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Add(CountryStates entity)
        {
            if(entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            _context.CountryStates.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(CountryStates entity)
        {
            if(entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            _context.CountryStates.Remove(entity);
            await _context.SaveChangesAsync();

        }

        public async Task<IEnumerable<CountryStates>> GetAll()
        {
            return await _context.CountryStates.ToListAsync();
        }

        public Task<CountryStates> GetByID(string guid)
        {
            if(guid == null)
            {
                throw new ArgumentNullException(nameof(guid));
            }
            if(int.TryParse(guid, out int countryGuid))
            {
                return _context.CountryStates.FirstOrDefaultAsync(c => c.Id == countryGuid);
            }
            return null;
        }

        public async Task Update(CountryStates entity)
        {
            if(entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            _context.CountryStates.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
