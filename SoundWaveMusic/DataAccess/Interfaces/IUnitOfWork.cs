using SoundWaveMusic.Interfaces;

namespace SoundWaveMusic.DataAccess.Interfaces
{
    public interface IUnitOfWork
    {
        IAlbumRepository AlbumRepository { get; }
        IArtistRepository ArtistRepository { get; }
        ICDRepository CDRepository { get; }
        IGenreRepository GenreRepository { get; }
        IOrderItemRepository OrderItemRepository { get; }
        IOrderRepository OrderRepository { get; }
        IProductRepository ProductRepository { get; }
        IVinylRepository VinylRepository { get; }

        void Dispose();
        Task<int> SaveAsync();
    }
}