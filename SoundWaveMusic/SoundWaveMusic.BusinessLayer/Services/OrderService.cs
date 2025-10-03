using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoundWaveMusic.Domain.Entities;
using SoundWaveMusic.DataAccess.Interfaces;
using SoundWaveMusic.BusinessLayer.Interfaces;

namespace SoundWaveMusic.BusinessLayer.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Order>> GetAllOrderAsync()
        {
            return await _unitOfWork.OrderRepository.GetAllAsync();
        }

        public async Task<Order?> GetOrderByIdAsync(int id)
        {
            return await _unitOfWork.OrderRepository.GetByIdAsync(id);
        }

        public async Task AddOrderAsync(Order order)
        {
            await _unitOfWork.OrderRepository.AddAsync(order);
            await _unitOfWork.SaveAsync();
        }

        public async Task UpdateOrderAsync(Order order)
        {
            _unitOfWork.OrderRepository.Update(order);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteOrderAsync(int id)
        {
            var order = await _unitOfWork.OrderRepository.GetByIdAsync(id);
            if (order != null)
            {
                _unitOfWork.OrderRepository.Delete(order);
                await _unitOfWork.SaveAsync();
            }
        }
    }
}
