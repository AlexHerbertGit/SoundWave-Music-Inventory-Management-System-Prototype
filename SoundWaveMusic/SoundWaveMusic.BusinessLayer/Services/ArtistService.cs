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
    public class ArtistService : IArtistService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ArtistService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Artist>> GetAllArtistsAsync()
        {
            return await _unitOfWork.ArtistRepository.GetAllAsync();
        }

        public async Task<Artist?> GetArtistByIdAsync(int id)
        {
            return await _unitOfWork.ArtistRepository.GetByIdAsync(id);
        }

        public async Task AddArtistAsync(Artist artist)
        {
            await _unitOfWork.ArtistRepository.AddAsync(artist);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<Artist>> GetGenreByIdAsync(int genreId)
        {
            return await _unitOfWork.ArtistRepository.GetGenreByIdASync(genreId);
        }

        public async Task AddAsync(Artist artist)
        {
            await _unitOfWork.ArtistRepository.AddAsync(artist);
            await _unitOfWork.SaveAsync();
        }

        public async Task UpdatAsync(Artist artist)
        {
            _unitOfWork.ArtistRepository.Update(artist);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var artist = await _unitOfWork.ArtistRepository.GetByIdAsync(id);
            if (artist != null)
            {
                _unitOfWork.ArtistRepository.Delete(artist);
                await _unitOfWork.SaveAsync();
            }
        }
    }
}
