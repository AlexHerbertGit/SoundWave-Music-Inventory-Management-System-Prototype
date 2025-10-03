using SoundWaveMusic.Domain.Entities;

namespace SoundWaveMusic.BusinessLayer.Interfaces
{
    public interface IArtistService
    {
        Task AddArtistAsync(Artist artist);
        Task AddAsync(Artist artist);
        Task DeleteAsync(int id);
        Task<IEnumerable<Artist>> GetAllArtistsAsync();
        Task<Artist?> GetArtistByIdAsync(int id);
        Task<IEnumerable<Artist>> GetGenreByIdAsync(int genreId);
        Task UpdatAsync(Artist artist);
    }
}