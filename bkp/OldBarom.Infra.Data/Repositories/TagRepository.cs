using Microsoft.EntityFrameworkCore;
using OldBarom.Core.Domain.Entities.Systempunk;
using OldBarom.Core.Domain.Interfaces;
using OldBarom.Infra.Data.Context;

namespace OldBarom.Infra.Data.Repositories
{
    public class TagRepository : ITagRepository
    {
        private readonly ApplicationDbContext _context;
        public TagRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Tag> CreateAsync(Tag tag)
        {
            _context.Tags.Add(tag);
            await _context.SaveChangesAsync();
            return tag;
        }

        public async Task<Tag> GetByIdAsync(int? id)
        {
            return await _context.Tags.FindAsync(id);
        }

        public async Task<IEnumerable<Tag>> GetTagsAsync()
        {
            return await _context.Tags.ToListAsync();
        }

        public async Task<Tag> RemoveAsync(Tag tag)
        {
            _context.Tags.Remove(tag);
            await _context.SaveChangesAsync();
            return tag;
        }

        public async Task<Tag> RemoveAsync(int id)
        {
            var tag = await _context.Tags.FindAsync(id);
            if (tag == null)
            {
                return null;
            }
            _context.Tags.Remove(tag);
            await _context.SaveChangesAsync();
            return tag;
        }

        public async Task<Tag> UpdateAsync(Tag tag)
        {
            var tagStorage = await _context.Tags.FindAsync(tag.Id);
            if (tagStorage == null)
            {
                return null;
            }
            _context.Tags.Update(tag);
            await _context.SaveChangesAsync();
            return tag;
        }
    }
}
