namespace SoundWaveMusic.DataAccess.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IAlbumRepository AlbumRepository { get; }
        IArtistRepository ArtistRepository { get; }
        IGenreRepository GenreRepository { get; }
        IOrderItemRepository OrderItemRepository { get; }
        IOrderRepository OrderRepository { get; }
        IProductRepository ProductRepository { get; }
        Task<int> SaveAsync();
    }
}