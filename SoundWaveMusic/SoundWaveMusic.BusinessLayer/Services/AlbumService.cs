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
    public class AlbumService : IAlbumService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AlbumService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Album>> GetAllAlbumsAsync()
        {
            return await _unitOfWork.AlbumRepository.GetAllAsync();
        }

        public async Task<Album?> GetAlbumByIdAsync(int id)
        {
            return await _unitOfWork.AlbumRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Album>> GetAlbumsByGenreIdAsync(int genreId)
        {
            return await _unitOfWork.AlbumRepository.GetGenreIdAsync(genreId);
        }

        public async Task<IEnumerable<Album>> GetAlbumsByArtistIdAsync(int artistId)
        {
            return await _unitOfWork.AlbumRepository.GetByArtistIdAsync(artistId);
        }

        public async Task AddAlbumAsync(Album album)
        {
            await _unitOfWork.AlbumRepository.AddAsync(album);
            await _unitOfWork.SaveAsync();
        }

        public async Task UpdateAsync(Album album)
        {
            _unitOfWork.AlbumRepository.Update(album);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            {
                var album = await _unitOfWork.AlbumRepository.GetByIdAsync(id);
                if (album != null)
                {
                    _unitOfWork.AlbumRepository.Delete(album);
                    await _unitOfWork.SaveAsync();
                }
            }

        }
    }
}
