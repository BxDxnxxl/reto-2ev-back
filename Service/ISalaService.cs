using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CineApi.Service
{
    public interface ISalaService
    {
        Task<List<Sala>> GetAllAsync();
        Task<Sala?> GetByIdAsync(int id);
        Task AddAsync(Sala sala);
        Task UpdateAsync(Sala sala);
        Task DeleteAsync(int id);
    }
}
