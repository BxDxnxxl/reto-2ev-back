using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CineApi.Service
{
    public interface ISesionService
    {
        Task<List<Sesion>> GetAllAsync();
        Task<Sesion?> GetByIdAsync(int id);
        Task AddAsync(Sesion sesion);
        Task DeleteAsync(int id);
    }
}
