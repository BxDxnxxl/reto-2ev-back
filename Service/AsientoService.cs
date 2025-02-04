using Models;
using CineApi.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CineApi.Service
{
    public class AsientoService : IAsientoService
    {
        private readonly IAsientoRepository _asientoRepository;

        public AsientoService(IAsientoRepository asientoRepository)
        {
            _asientoRepository = asientoRepository;
        }

        public async Task<List<Asiento>> GetAllAsync()
        {
            return await _asientoRepository.GetAllAsync();
        }

        public async Task AddAsync(Asiento asiento)
        {
            await _asientoRepository.AddAsync(asiento);
        }

    }
}
