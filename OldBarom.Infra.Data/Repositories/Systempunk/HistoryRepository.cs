using OldBarom.Core.Domain.Interface.Systempunk;
using OldBarom.Core.Domain.Model.Systempunk;
using OldBarom.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldBarom.Infra.Data.Repositories.Systempunk
{
    public class HistoryRepository : IHistoryRepository
    {
        private ApplicationDbContext _context;
        public HistoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<History> AddHistory(History history)
        {
            _context.Histories.Add(history);
            await _context.SaveChangesAsync();
            return history;
        }

        public async Task<History> DeleteHistory(Guid id)
        {
            _context.Histories.Remove(await GetHistory(id));
            await _context.SaveChangesAsync();
            return await GetHistory(id);
        }

        public async Task<IEnumerable<History>> GetHistories()
        {
            return _context.Histories.ToList();
        }

        public async Task<History> GetHistory(Guid id)
        {
            return await _context.Histories.FindAsync(id);
        }

        public async Task<IEnumerable<History>> GetHistoryByName(string name)
        {
            var history =  _context.Histories.Where(x => x.Name == name).ToList();
            return history;
        }

        public async Task<History> UpdateHistory(Guid id, History history)
        {
            _context.Histories.Update(history);
            await _context.SaveChangesAsync();
            return history;
        }
    }
}
