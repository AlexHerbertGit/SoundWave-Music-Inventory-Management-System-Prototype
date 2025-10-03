using SoundWaveMusic.Entities;

namespace BusinessLayer.Interfaces
{
    public interface IVinylService
    {
        Task AddVinylAsync(Vinyl vinyl);
        Task DeleteVinylAsync(int id);
        Task<IEnumerable<Vinyl>> GetAllVinylsAsync();
        Task<Vinyl?> GetVinylByIdAsync(int id);
        Task UpdateVinylAsync(Vinyl vinyl);
    }
}