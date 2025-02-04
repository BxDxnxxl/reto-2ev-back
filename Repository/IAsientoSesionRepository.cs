using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CineApi.Repositories
{
    public interface IAsientoSesionRepository
    {
        Task<List<AsientoSesion>> GetAllAsync();
        Task<List<AsientoSesion>> GetBySesionAsync(int sesionId);
//        Task<AsientoSesion?> GetByIdAsync(int id);
        Task AddAsync(AsientoSesion asientoSesion);
//        Task UpdateAsync(AsientoSesion asientoSesion);
//        Task DeleteAsync(int id);
    }
}
