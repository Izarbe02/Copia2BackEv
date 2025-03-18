using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dosEvAPI.Repositories
{
    public interface IPatrocinadorRepository
    {
        Task<List<Patrocinador>> GetAllAsync();
        Task<Patrocinador?> GetByIdAsync(int id);
        Task AddAsync(Patrocinador patrocinador);
        Task UpdateAsync(Patrocinador patrocinador);
        Task DeleteAsync(int id);
    }
}
