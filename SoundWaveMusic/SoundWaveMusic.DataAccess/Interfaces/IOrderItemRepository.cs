using SoundWaveMusic.Domain.Entities;

namespace SoundWaveMusic.DataAccess.Interfaces
{
    public interface IOrderItemRepository
    {
        Task<IEnumerable<OrderItem>> GetAllAsync();
        Task AddAsync(OrderItem item);
        void Delete(OrderItem item);
        Task<IEnumerable<OrderItem>> GetOrderItemByIdAsync(int orderId);
    }
}