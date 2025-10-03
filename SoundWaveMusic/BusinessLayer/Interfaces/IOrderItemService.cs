using SoundWaveMusic.Entities;

namespace BusinessLayer.Interfaces
{
    public interface IOrderItemService
    {
        Task<IEnumerable<OrderItem>> GetAllOrderItemsAsync();
        Task AddAsync(OrderItem item);
        Task DeleteAsync(int id);
        Task<IEnumerable<OrderItem>> GetOrderItemByIdAsync(int orderId);
    }
}