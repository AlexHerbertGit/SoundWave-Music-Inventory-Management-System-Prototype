using SoundWaveMusic.Entities;

namespace BusinessLayer.Interfaces
{
    public interface IAlbumService
    {
        Task AddAlbumAsync(Album album);
        Task DeleteAsync(int id);
        Task<Album?> GetAlbumByIdAsync(int id);
        Task<IEnumerable<Album>> GetAlbumsByArtistIdAsync(int artistId);
        Task<IEnumerable<Album>> GetAlbumsByGenreIdAsync(int genreId);
        Task<IEnumerable<Album>> GetAllAlbumsAsync();
        Task UpdateAsync(Album album);
    }
}