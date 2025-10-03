using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SoundWaveMusic.DataAccess.Data;
using SoundWaveMusic.Entities;
using SoundWaveMusic.Interfaces;

namespace SoundWaveMusic.Repositories
{
    public class CDRepository : ICDRepository
    {
        private readonly SoundWaveDbContext _context;

        public CDRepository(SoundWaveDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CD>> GetAllAsync()
        {
            return await _context.CDs
                .Include(c => c.Album)
                .ThenInclude(a => a.Artist)
                .ToListAsync();
        }

        public async Task<CD?> GetByIdAsync(int id)
        {
            return await _context.CDs
                .AsNoTracking()
                .Include(c => c.Album)
                .ThenInclude(a => a.Artist)
                .FirstOrDefaultAsync(c => c.ProductId == id);
        }

        public async Task AddAsync(CD cd)
        {
            await _context.CDs.AddAsync(cd);
        }

        public async Task UpdateAsync(CD cd)
        {
            _context.CDs.Update(cd);
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(int id)
        {
            var cd = await GetByIdAsync(id);
            if (cd != null)
            {
                _context.CDs.Remove(cd);
            }
        }
    }
}
