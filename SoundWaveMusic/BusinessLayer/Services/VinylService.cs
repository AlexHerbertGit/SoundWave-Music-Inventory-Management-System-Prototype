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
    public class VinylService : IVinylService
    {
        private readonly IUnitOfWork _unitOfWork;

        public VinylService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Vinyl>> GetAllVinylsAsync()
        {
            return await _unitOfWork.VinylRepository.GetAllAsync();
        }

        public async Task<Vinyl?> GetVinylByIdAsync(int id)
        {
            return await _unitOfWork.VinylRepository.GetByIdAsync(id);
        }

        public async Task AddVinylAsync(Vinyl vinyl)
        {
            await _unitOfWork.VinylRepository.AddAsync(vinyl);
            await _unitOfWork.SaveAsync();
        }

        public async Task UpdateVinylAsync(Vinyl vinyl)
        {
            await _unitOfWork.VinylRepository.UpdateAsync(vinyl);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteVinylAsync(int id)
        {
            await _unitOfWork.VinylRepository.DeleteAsync(id);
            await _unitOfWork.SaveAsync();
        }
    }
}
