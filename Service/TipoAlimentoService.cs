using Models;
using CineApi.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CineApi.Service
{
    public class TipoAlimentoService : ITipoAlimentoService
    {
        private readonly ITipoAlimentoRepository _tipoAlimentoRepository;

        public TipoAlimentoService(ITipoAlimentoRepository tipoAlimentoRepository)
        {
            _tipoAlimentoRepository = tipoAlimentoRepository;
        }

        public async Task<List<TipoAlimento>> GetAllAsync()
        {
            return await _tipoAlimentoRepository.GetAllAsync();
        }

        public async Task<TipoAlimento?> GetByIdAsync(int id)
        {
            return await _tipoAlimentoRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(TipoAlimento tipoAlimento)
        {
            await _tipoAlimentoRepository.AddAsync(tipoAlimento);
        }

        public async Task UpdateAsync(TipoAlimento tipoAlimento)
        {
            await _tipoAlimentoRepository.UpdateAsync(tipoAlimento);
        }

        public async Task DeleteAsync(int id)
        {
            await _tipoAlimentoRepository.DeleteAsync(id);
        }
    }
}
