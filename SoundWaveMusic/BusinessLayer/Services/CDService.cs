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
    public class CDService : ICDService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CDService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<CD>> GetAllCDsAsync()
        {
            return await _unitOfWork.CDRepository.GetAllAsync();
        }

        public async Task<CD?> GetCDByIdAsync(int id)
        {
            return await _unitOfWork.CDRepository.GetByIdAsync(id);
        }

        public async Task AddCDAsync(CD cd)
        {
            await _unitOfWork.CDRepository.AddAsync(cd);
            await _unitOfWork.SaveAsync();
        }

        public async Task UpdateCDAsync(CD cd)
        {
            await _unitOfWork.CDRepository.UpdateAsync(cd);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteCDAsync(int id)
        {
            await _unitOfWork.CDRepository.DeleteAsync(id);
            await _unitOfWork.SaveAsync();
        }

    }
}
