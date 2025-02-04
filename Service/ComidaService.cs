using Models;
using CineApi.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CineApi.Service
{
    public class ComidaService : IComidaService
    {
        private readonly IComidaRepository _comidaRepository;

        public ComidaService(IComidaRepository comidaRepository)
        {
            _comidaRepository = comidaRepository;
        }

        public async Task<List<Comida>> GetAllAsync()
        {
            return await _comidaRepository.GetAllAsync();
        }

        public async Task<Comida?> GetByIdAsync(int id)
        {
            return await _comidaRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(Comida comida)
        {
            await _comidaRepository.AddAsync(comida);
        }

        public async Task UpdateAsync(Comida comida)
        {
            await _comidaRepository.UpdateAsync(comida);
        }

        public async Task DeleteAsync(int id)
        {
            await _comidaRepository.DeleteAsync(id);
        }
    }
}
