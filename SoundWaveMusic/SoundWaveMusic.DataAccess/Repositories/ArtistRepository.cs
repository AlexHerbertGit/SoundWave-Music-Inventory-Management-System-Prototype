using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SoundWaveMusic.Domain.Entities;
using SoundWaveMusic.DataAccess.Data;
using SoundWaveMusic.DataAccess.Interfaces;


namespace SoundWaveMusic.DataAccess.Repositories
{
    public class ArtistRepository : IArtistRepository
    {
        private readonly SoundWaveDbContext _context;

        public ArtistRepository(SoundWaveDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Artist>> GetAllAsync()
        {
            return await _context.Artists.ToListAsync();
        }

        public async Task<Artist?> GetByIdAsync(int id)
        {
            return await _context.Artists.FindAsync(id);
        }

        public async Task<IEnumerable<Artist>> GetGenreByIdASync(int genreId)
        {
            return await _context.Artists
                .Where(a => a.GenreId == genreId)
                .ToListAsync();
        }
        public async Task AddAsync(Artist artist)
        {
            await _context.Artists.AddAsync(artist);
        }

        public void Update(Artist artist)
        {
            _context.Artists.Update(artist);
        }

        public void Delete(Artist artist)
        {
            _context.Artists.Remove(artist);
        }
    }
}
