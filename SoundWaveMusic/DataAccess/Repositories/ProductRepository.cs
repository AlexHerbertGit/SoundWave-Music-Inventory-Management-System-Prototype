using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoundWaveMusic.Domain.Entities;
using SoundWaveMusic.DataAccess.Data;
using DataAccess.Interfaces;

namespace SoundWaveMusic.DataAccess.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly SoundWaveDbContext _context;

        public ProductRepository(SoundWaveDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products
                .Include(p => p.Album)
                .ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _context.Products
                .Include(p => p.Album)
                .FirstOrDefaultAsync(p => p.ProductId == id);
        }

        public async Task<IEnumerable<Product>> GetByAlbumId(int albumid)
        {
            return await _context.Products
                .Where(p => p.AlbumId == albumid)
                .Include(p => p.Album)
                .ToListAsync();
        }

        public async Task<IEnumerable<CD>> GetAllCDsAsync()
        {
            return await _context.CDs
                .Include(cd => cd.Album)
                .ToListAsync();
        }

        public async Task<IEnumerable<Vinyl>> GetAllVinylAsync()
        {
            return await _context.Vinyls
                .Include(v => v.Album)
                .ToListAsync();
        }

        public async Task AddAsync(Product product)
        {
            await _context.Products.AddAsync(product);
        }

        public void Update(Product product)
        {
            _context.Products.Update(product);
        }
        public void Delete(Product product)
        {
            _context.Products.Remove(product);
        }
    }
}
