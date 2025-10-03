using SoundWaveMusic.Entities;

namespace BusinessLayer.Interfaces
{
    public interface IGenreService
    {
        Task AddGenreAsync(Genre genre);
        Task DeleteGenreAsync(int id);
        Task<IEnumerable<Genre>> GetAllGenresAsync();
        Task<Genre?> GetGenreByIdAsync(int id);
        Task UpdateGenreAsync(Genre genre);
    }
}