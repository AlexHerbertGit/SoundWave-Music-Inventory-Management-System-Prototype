using SoundWaveMusic.Entities;

namespace BusinessLayer.Interfaces
{
    public interface ICDService
    {
        Task AddCDAsync(CD cd);
        Task DeleteCDAsync(int id);
        Task<IEnumerable<CD>> GetAllCDsAsync();
        Task<CD?> GetCDByIdAsync(int id);
        Task UpdateCDAsync(CD cd);
    }
}