using SoundWaveMusic.Entities;

namespace SoundWaveMusic.Interfaces
{
    public interface IOrderRepository
    {
        Task AddAsync(Order order);
        void Delete(Order order);
        void Update(Order order);
        Task<IEnumerable<Order>> GetAllAsync();
        Task<Order?> GetByIdAsync(int id);
    }
}