using SoundWaveMusic.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IGenreRepository
    {
        Task AddAsync(Genre genre);
        void Delete(Genre genre);
        Task<IEnumerable<Genre>> GetAllAsync();
        Task<Genre?> GetByIdAsync(int id);
        void Update(Genre genre);
    }
}