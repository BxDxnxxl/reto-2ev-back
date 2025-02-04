using Models;
using CineApi.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CineApi.Service
{
    public class ProveedorService : IProveedorService
    {
        private readonly IProveedorRepository _proveedorRepository;

        public ProveedorService(IProveedorRepository proveedorRepository)
        {
            _proveedorRepository = proveedorRepository;
        }

        public async Task<List<Proveedor>> GetAllAsync()
        {
            return await _proveedorRepository.GetAllAsync();
        }

        public async Task<Proveedor?> GetByIdAsync(int id)
        {
            return await _proveedorRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(Proveedor proveedor)
        {
            await _proveedorRepository.AddAsync(proveedor);
        }

        public async Task UpdateAsync(Proveedor proveedor)
        {
            await _proveedorRepository.UpdateAsync(proveedor);
        }

        public async Task DeleteAsync(int id)
        {
            await _proveedorRepository.DeleteAsync(id);
        }
    }
}
