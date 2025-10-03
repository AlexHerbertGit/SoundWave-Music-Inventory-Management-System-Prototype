using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SoundWaveMusic.Domain.Entities;
using SoundWaveMusic.DataAccess.Data;
using DataAccess.Interfaces;

namespace SoundWaveMusic.DataAccess.Repositories
{
    public class AlbumRepository : IAlbumRepository
    {
        private readonly SoundWaveDbContext _context;

        public AlbumRepository(SoundWaveDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Album>> GetAllAsync()
        {
            return await _context.Albums
                .Include(a => a.Artist)
                .Include(a => a.Genre)
                .ToListAsync();
        }

        public async Task<Album?> GetByIdAsync(int id)
        {
            return await _context.Albums
                .Include(a => a.Artist)
                .Include(a => a.Genre)
                .FirstOrDefaultAsync(a => a.AlbumId == id);
        }

        public async Task<IEnumerable<Album>> GetGenreIdAsync(int genreId)
        {
            return await _context.Albums
                .Where(a => a.GenreId == genreId)
                .Include(a => a.Genre)
                .ToListAsync();
        }

        public async Task<IEnumerable<Album>> GetByArtistIdAsync(int artistId)
        {
            return await _context.Albums
                .Where(a => a.ArtistId == artistId)
                .Include(a => a.Artist)
                .ToListAsync();
        }

        public async Task AddAsync(Album album)
        {
            await _context.Albums.AddAsync(album);
            await _context.SaveChangesAsync();
        }

        public void Update(Album album)
        {
            _context.Albums.Update(album);
        }

        public void Delete(Album album)
        {
            _context.Albums.Remove(album);
        }
    }
}
