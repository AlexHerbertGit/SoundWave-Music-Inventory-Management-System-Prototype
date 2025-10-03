using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Interfaces;
using SoundWaveMusic.Entities;
using SoundWaveMusic.DataAccess.Interfaces;

namespace BusinessLayer.Services
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
            //Load product data for each order item
            foreach (var item in order.OrderItems)
            {
                item.Product = await _unitOfWork.ProductRepository.GetByIdAsync(item.ProductId);
            }

            //Calculate order totals
            order.Subtotal = order.OrderItems.Sum(item => item.Product.Price * item.Quantity);
            order.ShippingCost = 5.00m;
            order.TotalCost = order.Subtotal + order.ShippingCost;
            order.OrderDateTime = DateTime.Now;

            await _unitOfWork.OrderRepository.AddAsync(order);
            await _unitOfWork.SaveAsync();
        }

        public async Task UpdateOrderAsync(Order order)
        {

            //Load product data for each order item
            foreach (var item in order.OrderItems)
            {
                item.Product = await _unitOfWork.ProductRepository.GetByIdAsync(item.ProductId);
            }

            //Calculate order totals
            order.Subtotal = order.OrderItems.Sum(item => item.Product.Price * item.Quantity);
            order.ShippingCost = 5.00m;
            order.TotalCost = order.Subtotal + order.ShippingCost;
            order.OrderDateTime = DateTime.Now;

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
