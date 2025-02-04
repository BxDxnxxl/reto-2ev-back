using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CineApi.Service
{
    public interface IComidaService
    {
        Task<List<Comida>> GetAllAsync();
        Task<Comida?> GetByIdAsync(int id);
        Task AddAsync(Comida comida);
        Task UpdateAsync(Comida comida);
        Task DeleteAsync(int id);
    }
}
