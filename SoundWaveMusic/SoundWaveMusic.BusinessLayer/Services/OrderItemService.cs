using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoundWaveMusic.BusinessLayer.Interfaces;
using SoundWaveMusic.DataAccess.Interfaces;
using SoundWaveMusic.Domain.Entities;

namespace SoundWaveMusic.BusinessLayer.Services
{
    public class OrderItemService : IOrderItemService
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderItemService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<OrderItem>> GetAllOrderItemsAsync()
        {
            return await _unitOfWork.OrderItemRepository.GetAllAsync();
        }

        public async Task<IEnumerable<OrderItem>> GetOrderItemByIdAsync(int orderId)
        {
            return await _unitOfWork.OrderItemRepository.GetOrderItemByIdAsync(orderId);
        }

        public async Task AddAsync(OrderItem item)
        {
            await _unitOfWork.OrderItemRepository.AddAsync(item);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var items = await _unitOfWork.OrderItemRepository.GetOrderItemByIdAsync(id);
            foreach (var item in items)
            {
                _unitOfWork.OrderItemRepository.Delete(item);
            }
            await _unitOfWork.SaveAsync();
        }
    }
}
