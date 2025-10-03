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
    public class GenreRepository : IGenreRepository
    {
        private readonly SoundWaveDbContext _context;

        public GenreRepository(SoundWaveDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Genre>> GetAllAsync()
        {
            return await _context.Genres.ToListAsync();
        }

        public async Task<Genre?> GetByIdAsync(int id)
        {
            return await _context.Genres.FindAsync(id);
        }

        public async Task AddAsync(Genre genre)
        {
            await _context.Genres.AddAsync(genre);
        }

        public void Update(Genre genre)
        {
            _context.Genres.Update(genre);
        }

        public void Delete(Genre genre)
        {
            _context.Genres.Remove(genre);
        }
    }
}
