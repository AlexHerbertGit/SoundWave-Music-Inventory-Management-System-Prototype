using SoundWaveMusic.Domain.Entities;

namespace SoundWaveMusic.BusinessLayer.Interfaces
{
    public interface IProductService
    {
        Task AddProductAsync(Product product);
        Task DeleteProductAsync(int id);
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<IEnumerable<Vinyl>> GetAllVinylsAsync();
        Task<IEnumerable<CD>> GetAllCDsAsync();
        Task<Product?> GetProductByIdAsync(int id);
        Task<IEnumerable<Product>> GetProductsByAlbumIdAsync(int albumId);
        Task UpdateProductAsync(Product product);
    }
}