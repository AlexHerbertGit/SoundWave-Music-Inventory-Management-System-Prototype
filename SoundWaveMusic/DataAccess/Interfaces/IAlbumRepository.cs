using SoundWaveMusic.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IAlbumRepository
    {
        Task AddAsync(Album album);
        void Delete(Album album);
        Task<IEnumerable<Album>> GetAllAsync();
        Task<IEnumerable<Album>> GetByArtistIdAsync(int artistId);
        Task<Album?> GetByIdAsync(int id);
        Task<IEnumerable<Album>> GetGenreIdAsync(int genreId);
        void Update(Album album);
    }
}