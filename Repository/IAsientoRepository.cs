using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CineApi.Repositories
{
    public interface IAsientoRepository
    {
        Task<List<Asiento>> GetAllAsync();
        Task<Asiento?> GetByIdAsync(int id);
        Task AddAsync(Asiento asiento);
        Task DeleteAsync(int id);
    }
}
