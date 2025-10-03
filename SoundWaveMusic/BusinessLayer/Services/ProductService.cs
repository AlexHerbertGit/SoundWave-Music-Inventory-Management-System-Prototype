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
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _unitOfWork.ProductRepository.GetAllAsync();
        }

        public async Task<Product?> GetProductByIdAsync(int id)
        {
            return await _unitOfWork.ProductRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Product>> GetProductsByAlbumIdAsync(int albumId)
        {
            return await _unitOfWork.ProductRepository.GetByAlbumId(albumId);
        }

        public async Task<IEnumerable<Vinyl>> GetAllVinylsAsync()
        {
            return await _unitOfWork.ProductRepository.GetAllVinylAsync();
        }

        public async Task<IEnumerable<CD>> GetAllCDsAsync()
        {
            return await _unitOfWork.ProductRepository.GetAllCDsAsync();
        }

        public async Task AddProductAsync(Product product)
        {
            await _unitOfWork.ProductRepository.AddAsync(product);
            await _unitOfWork.SaveAsync();
        }

        public async Task UpdateProductAsync(Product product)
        {
            _unitOfWork.ProductRepository.Update(product);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteProductAsync(int id)
        {
            var product = await _unitOfWork.ProductRepository.GetByIdAsync(id);
            if (product != null)
            {
                _unitOfWork.ProductRepository.Delete(product);
                await _unitOfWork.SaveAsync();
            }
        }
    }
}
