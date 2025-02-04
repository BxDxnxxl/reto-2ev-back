using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CineApi.Service
{
    public interface IAsientoService
    {
        Task<List<Asiento>> GetAllAsync();
//        Task<List<Asiento>> GetBySalaAsync(int salaId);
//        Task<Asiento?> GetByIdAsync(int salaId, int fila, int numero);
        Task AddAsync(Asiento asiento);
//        Task DeleteAsync(int salaId, int fila, int numero);
    }
}
