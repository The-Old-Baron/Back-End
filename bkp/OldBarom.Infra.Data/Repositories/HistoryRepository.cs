using Microsoft.EntityFrameworkCore;
using OldBarom.Core.Domain.Entities.Systempunk;
using OldBarom.Core.Domain.Interfaces;
using OldBarom.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldBarom.Infra.Data.Repositories
{
    public class HistoryRepository : IHistoryRepository

    {
        private readonly ApplicationDbContext _context;
        public HistoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<History> CreateAsync(History history)
        {
            await _context.Histories.AddAsync(history);
            await _context.SaveChangesAsync();
            return history;
        }

        public async Task<History> DeleteAsync(History history)
        {
            _context.Histories.Remove(history);
            await _context.SaveChangesAsync();
            return history;
        }

        public async Task<History> DeleteAsync(int id)
        {
            var history = _context.Histories.Find(id);
            if (history == null)
            {
                return null;
            }
            _context.Histories.Remove(history);
            await _context.SaveChangesAsync();
            return history;

        }

        public async Task<IEnumerable<History>> GetHistoriesAsync()
        {
            return await _context.Histories.ToListAsync();
        }

        public async Task<History> GetHistoryByID(int id)
        {
            var history = await _context.Histories.FindAsync(id);
            return history;
            
        }

        public async Task<History> UpdateAsync(History history)
        {
            var storegeHistory = _context.Histories.FindAsync(history.Id);
            if (storegeHistory == null)
            {
                return null;
            }
            _context.Histories.Update(history);
            await _context.SaveChangesAsync();
            return history;
        }
    }
}
