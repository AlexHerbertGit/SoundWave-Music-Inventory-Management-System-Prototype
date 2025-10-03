using SoundWaveMusic.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IOrderRepository
    {
        Task AddAsync(Order order);
        void Delete(Order order);
        Task<IEnumerable<Order>> GetAllAsync();
        Task<Order?> GetByIdAsync(int id);
        void Update(Order order);
    }
}