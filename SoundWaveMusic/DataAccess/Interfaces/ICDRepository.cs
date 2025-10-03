using SoundWaveMusic.Entities;

namespace SoundWaveMusic.Interfaces
{
    public interface ICDRepository
    {
        Task AddAsync(CD cd);
        Task DeleteAsync(int id);
        Task<IEnumerable<CD>> GetAllAsync();
        Task<CD?> GetByIdAsync(int id);
        Task UpdateAsync(CD cd);
    }
}