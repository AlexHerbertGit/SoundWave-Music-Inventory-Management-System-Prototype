using SoundWaveMusic.Domain.Entities;

namespace SoundWaveMusic.DataAccess.Interfaces
{
    public interface IGenreRepository
    {
        Task AddAsync(Genre genre);
        void Delete(Genre genre);
        Task<IEnumerable<Genre>> GetAllAsync();
        Task<Genre?> GetByIdAsync(int id);
        void Update(Genre genre);
    }
}