using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dosEvAPI.Service
{
    public interface IPatrocinadorService
    {
        Task<List<Patrocinador>> GetAllAsync();
        Task<Patrocinador?> GetByIdAsync(int id);
        Task AddAsync(Patrocinador patrocinador);
        Task UpdateAsync(Patrocinador patrocinador);
        Task DeleteAsync(int id);
    }
}
