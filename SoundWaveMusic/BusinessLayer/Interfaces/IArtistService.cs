using SoundWaveMusic.Entities;

namespace BusinessLayer.Interfaces
{
    public interface IArtistService
    {
        Task AddArtistAsync(Artist artist);
        Task DeleteAsync(int id);
        Task<IEnumerable<Artist>> GetAllArtistsAsync();
        Task<Artist?> GetArtistByIdAsync(int id);
        Task<IEnumerable<Artist>> GetGenreByIdAsync(int genreId);
        Task UpdateAsync(Artist artist);
    }
}