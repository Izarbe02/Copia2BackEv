using Models;
using dosEvAPI.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dosEvAPI.Service
{
    public class PatrocinadorService : IPatrocinadorService
    {
        private readonly IPatrocinadorRepository _patrocinadorRepository;

        public PatrocinadorService(IPatrocinadorRepository patrocinadorRepository)
        {
            _patrocinadorRepository = patrocinadorRepository;
        }

        public async Task<List<Patrocinador>> GetAllAsync()
        {
            return await _patrocinadorRepository.GetAllAsync();
        }

        public async Task<Patrocinador?> GetByIdAsync(int id)
        {
            return await _patrocinadorRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(Patrocinador patrocinador)
        {
            await _patrocinadorRepository.AddAsync(patrocinador);
        }

        public async Task UpdateAsync(Patrocinador patrocinador)
        {
            await _patrocinadorRepository.UpdateAsync(patrocinador);
        }

        public async Task DeleteAsync(int id)
        {
            await _patrocinadorRepository.DeleteAsync(id);
        }
    }
}
