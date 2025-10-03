using SoundWaveMusic.Entities;

namespace SoundWaveMusic.Interfaces;

public interface IArtistRepository
{
    Task AddAsync(Artist artist);
    void Delete(Artist artist);
    Task<IEnumerable<Artist>> GetAllAsync();
    Task<Artist?> GetByIdAsync(int id);
    Task<IEnumerable<Artist>> GetGenreByIdASync(int genreId);
    void Update(Artist artist);
}