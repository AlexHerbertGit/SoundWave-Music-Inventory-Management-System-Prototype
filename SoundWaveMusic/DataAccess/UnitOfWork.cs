using SoundWaveMusic.Repositories;
using System.Threading.Tasks;
using SoundWaveMusic.Interfaces;
using SoundWaveMusic.DataAccess.Data;
using SoundWaveMusic.DataAccess.Interfaces;

namespace SoundWaveMusic.DataAccess
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private readonly SoundWaveDbContext _context;

        public IAlbumRepository AlbumRepository { get; }
        public IArtistRepository ArtistRepository { get; }
        public IGenreRepository GenreRepository { get; }
        public IProductRepository ProductRepository { get; }
        public IOrderRepository OrderRepository { get; }
        public IOrderItemRepository OrderItemRepository { get; }

        // ✅ New repositories
        public ICDRepository CDRepository { get; }
        public IVinylRepository VinylRepository { get; }

        public UnitOfWork(SoundWaveDbContext context)
        {
            _context = context;

            AlbumRepository = new AlbumRepository(_context);
            ArtistRepository = new ArtistRepository(_context);
            GenreRepository = new GenreRepository(_context);
            ProductRepository = new ProductRepository(_context);
            OrderRepository = new OrderRepository(_context);
            OrderItemRepository = new OrderItemRepository(_context);

            // ✅ Initialize the new repos
            CDRepository = new CDRepository(_context);
            VinylRepository = new VinylRepository(_context);
        }

        public async Task<int> SaveAsync() => await _context.SaveChangesAsync();

        public void Dispose() => _context.Dispose();
    }
}
