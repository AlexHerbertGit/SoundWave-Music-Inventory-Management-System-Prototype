using SoundWaveMusic.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IProductRepository
    {
        Task AddAsync(Product product);
        void Delete(Product product);
        Task<IEnumerable<Product>> GetAllAsync();
        Task<IEnumerable<CD>> GetAllCDsAsync();
        Task<IEnumerable<Vinyl>> GetAllVinylAsync();
        Task<IEnumerable<Product>> GetByAlbumId(int albumid);
        Task<Product?> GetByIdAsync(int id);
        void Update(Product product);
    }
}