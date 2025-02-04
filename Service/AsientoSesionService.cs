using Models;
using CineApi.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CineApi.Service
{
    public class AsientoSesionService : IAsientoSesionService
    {
        private readonly IAsientoSesionRepository _asientoSesionRepository;

        public AsientoSesionService(IAsientoSesionRepository asientoSesionRepository)
        {
            _asientoSesionRepository = asientoSesionRepository;
        }

        public async Task<List<AsientoSesion>> GetAllAsync()
        {
            return await _asientoSesionRepository.GetAllAsync();
        }

        public async Task<List<AsientoSesion>> GetBySesionAsync(int sesionId)
        {
            return await _asientoSesionRepository.GetBySesionAsync(sesionId);
        }


        public async Task AddAsync(AsientoSesion asientoSesion)
        {
            await _asientoSesionRepository.AddAsync(asientoSesion);
        }
    }
}
