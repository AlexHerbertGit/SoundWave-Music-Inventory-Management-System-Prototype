using DataAccess.Interfaces;
using SoundWaveMusic.DataAccess.Data;
using SoundWaveMusic.DataAccess.Repositories;
using SoundWaveMusic.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundWaveMusic.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SoundWaveDbContext _context;

        public IAlbumRepository AlbumRepository { get; set; }
        public IArtistRepository ArtistRepository { get; set; }
        public IGenreRepository GenreRepository { get; set; }
        public IProductRepository ProductRepository { get; set; }
        public IOrderRepository OrderRepository { get; set; }
        public IOrderItemRepository OrderItemRepository { get; set; }

        public UnitOfWork(SoundWaveDbContext context)
        {
            _context = context;

            AlbumRepository = new AlbumRepository(_context);
            ArtistRepository = new ArtistRepository(_context);
            GenreRepository = new GenreRepository(_context);
            ProductRepository = new ProductRepository(_context);
            OrderRepository = new OrderRepository(_context);
            OrderItemRepository = new OrderItemRepository(_context);
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
