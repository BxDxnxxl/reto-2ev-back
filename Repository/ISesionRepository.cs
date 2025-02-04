using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CineApi.Repositories
{
    public interface ISesionRepository
    {
        Task<List<Sesion>> GetAllAsync();
        Task<Sesion?> GetByIdAsync(int id);
//        Task<List<Sesion>> GetByPeliculaAsync(int peliculaId);
//      Task<List<Sesion>> GetBySalaAsync(int salaId);
        Task AddAsync(Sesion sesion);
        Task UpdateAsync(Sesion sesion);
        Task DeleteAsync(int id);
    }
}
