using SoundWaveMusic.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IOrderItemRepository
    {
        Task AddAsync(OrderItem item);
        void Delete(OrderItem item);
        Task<IEnumerable<OrderItem>> GetAllAsync();
        Task<IEnumerable<OrderItem>> GetOrderItemByIdAsync(int orderId);
    }
}