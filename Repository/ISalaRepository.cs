using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CineApi.Repositories
{
    public interface ISalaRepository
    {
        Task<List<Sala>> GetAllAsync();
        Task<Sala?> GetByIdAsync(int id);
        Task AddAsync(Sala sala);
        Task UpdateAsync(Sala sala);
        Task DeleteAsync(int id);
    }
}
