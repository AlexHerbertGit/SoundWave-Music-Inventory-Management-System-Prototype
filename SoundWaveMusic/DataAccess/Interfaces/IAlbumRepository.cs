using SoundWaveMusic.Entities;

namespace SoundWaveMusic.Interfaces;

public interface IAlbumRepository
{
    Task AddAsync(Album album);
    void Delete(Album album);
    Task<IEnumerable<Album>> GetAllAsync();
    Task<Album?> GetByIdAsync(int id);
    Task<IEnumerable<Album>> GetGenreIdAsync(int genreId);
    Task<IEnumerable<Album>> GetByArtistIdAsync(int artistId);
    void Update(Album album);
}