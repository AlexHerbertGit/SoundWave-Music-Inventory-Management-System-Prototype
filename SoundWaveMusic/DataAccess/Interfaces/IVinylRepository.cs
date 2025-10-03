using SoundWaveMusic.Entities;

namespace SoundWaveMusic.Interfaces
{
    public interface IVinylRepository
    {
        Task AddAsync(Vinyl vinyl);
        Task DeleteAsync(int id);
        Task<IEnumerable<Vinyl>> GetAllAsync();
        Task<Vinyl?> GetByIdAsync(int id);
        Task UpdateAsync(Vinyl vinyl);
    }
}