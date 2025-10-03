using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoundWaveMusic.BusinessLayer.Interfaces;
using SoundWaveMusic.DataAccess;
using SoundWaveMusic.DataAccess.Interfaces;
using SoundWaveMusic.DataAccess.Repositories;
using SoundWaveMusic.Domain.Entities;

namespace SoundWaveMusic.BusinessLayer.Services
{
    public class GenreService : IGenreService
    {
        private readonly IUnitOfWork _unitOfWork;

        public GenreService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Genre>> GetAllGenresAsync()
        {
            return await _unitOfWork.GenreRepository.GetAllAsync();
        }

        public async Task<Genre?> GetGenreByIdAsync(int id)
        {
            return await _unitOfWork.GenreRepository.GetByIdAsync(id);
        }

        public async Task AddGenreAsync(Genre genre)
        {
            await _unitOfWork.GenreRepository.AddAsync(genre);
            await _unitOfWork.SaveAsync();
        }

        public async Task UpdateGenreAsync(Genre genre)
        {
            _unitOfWork.GenreRepository.Update(genre);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteGenreAsync(int id)
        {
            var genre = await _unitOfWork.GenreRepository.GetByIdAsync(id);
            if (genre != null)
            {
                _unitOfWork.GenreRepository.Delete(genre);
                await _unitOfWork.SaveAsync();
            }
        }
    }
}
