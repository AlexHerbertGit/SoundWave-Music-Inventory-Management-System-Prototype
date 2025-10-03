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
    public class VinylRepository : IVinylRepository
    {
        private readonly SoundWaveDbContext _context;

        public VinylRepository(SoundWaveDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Vinyl>> GetAllAsync()
        {
            return await _context.Vinyls
                .Include(v => v.Album)
                .ThenInclude(a => a.Artist)
                .ToListAsync();
        }

        public async Task<Vinyl?> GetByIdAsync(int id)
        {
            return await _context.Vinyls
                .AsNoTracking()
                .Include(v => v.Album)
                .ThenInclude(a => a.Artist)
                .FirstOrDefaultAsync(v => v.ProductId == id);
        }

        public async Task AddAsync(Vinyl vinyl)
        {
            await _context.Vinyls.AddAsync(vinyl);
        }

        public async Task UpdateAsync(Vinyl vinyl)
        {
            _context.Vinyls.Update(vinyl);
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(int id)
        {
            var vinyl = await GetByIdAsync(id);
            if (vinyl != null)
            {
                _context.Vinyls.Remove(vinyl);
            }
        }
    }
}
