using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SoundWaveMusic.DataAccess.Data;
using SoundWaveMusic.Entities;
using SoundWaveMusic.Interfaces;

namespace SoundWaveMusic.Repositories
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly SoundWaveDbContext _context;

        public OrderItemRepository(SoundWaveDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<OrderItem>> GetAllAsync()
        {
            return await _context.OrderItems
                .Include(o => o.Order)
                .Include(o => o.Product)
                .ToListAsync();
        }

        public async Task<IEnumerable<OrderItem>> GetOrderItemByIdAsync(int orderId)
        {
            return await _context.OrderItems
                .Where(oi => oi.OrderId == orderId)
                .Include(oi => oi.Product)
                    .ThenInclude(p => p.Album)
                .ThenInclude(a => a.Artist)
                .Include(oi => oi.Product)
                    .ThenInclude(p => p.Album)
                .ThenInclude(a => a.Genre)
                .ToListAsync();
        }

        public async Task AddAsync(OrderItem item)
        {
            await _context.OrderItems.AddAsync(item);
        }

        public void Delete(OrderItem item)
        {
            _context.OrderItems.Remove(item);
        }
    }
}
