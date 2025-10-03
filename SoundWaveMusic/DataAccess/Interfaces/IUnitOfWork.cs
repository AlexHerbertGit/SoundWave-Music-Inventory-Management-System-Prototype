using DataAccess.Interfaces;
using System.Threading.Tasks;

namespace SoundWaveMusic.DataAccess.Interfaces
{
    public interface IUnitOfWork
    {
        IAlbumRepository AlbumRepository { get; set; }
        IArtistRepository ArtistRepository { get; set; }
        IGenreRepository GenreRepository { get; set; }
        IOrderItemRepository OrderItemRepository { get; set; }
        IOrderRepository OrderRepository { get; set; }
        IProductRepository ProductRepository { get; set; }

        void Dispose();
        Task<int> SaveAsync();
    }
}