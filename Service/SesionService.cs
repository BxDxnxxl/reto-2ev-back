using Models;
using CineApi.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CineApi.Service
{
    public class SesionService : ISesionService
    {
        private readonly ISesionRepository _sesionRepository;

        public SesionService(ISesionRepository sesionRepository)
        {
            _sesionRepository = sesionRepository;
        }

        public async Task<List<Sesion>> GetAllAsync()
        {
            return await _sesionRepository.GetAllAsync();
        }

        public async Task<Sesion?> GetByIdAsync(int id)
        {
            return await _sesionRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(Sesion sesion)
        {
            await _sesionRepository.AddAsync(sesion);
        }

        public async Task DeleteAsync(int id)
        {
            await _sesionRepository.DeleteAsync(id);
        }
    }
}
