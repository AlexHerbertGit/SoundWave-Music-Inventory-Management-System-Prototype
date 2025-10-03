using SoundWaveMusic.Domain.Entities;

namespace SoundWaveMusic.BusinessLayer.Interfaces
{
    public interface IOrderService
    {
        Task AddOrderAsync(Order order);
        Task DeleteOrderAsync(int id);
        Task UpdateOrderAsync(Order order);
        Task<IEnumerable<Order>> GetAllOrderAsync();
        Task<Order?> GetOrderByIdAsync(int id);
    }
}