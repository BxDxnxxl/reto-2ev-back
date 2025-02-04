using Models;
using CineApi.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CineApi.Service
{
    public class CompraService : ICompraService
    {
        private readonly ICompraRepository _compraRepository;

        public CompraService(ICompraRepository compraRepository)
        {
            _compraRepository = compraRepository;
        }

        public async Task<List<Compra>> GetAllAsync()
        {
            return await _compraRepository.GetAllAsync();
        }

        public async Task<Compra?> GetByIdAsync(int id)
        {
            return await _compraRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(Compra compra)
        {
            await _compraRepository.AddAsync(compra);
        }

        public async Task UpdateAsync(Compra compra)
        {
            await _compraRepository.UpdateAsync(compra);
        }

        public async Task DeleteAsync(int id)
        {
            await _compraRepository.DeleteAsync(id);
        }
    }
}
