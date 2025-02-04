using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CineApi.Service
{
    public interface IAsientoSesionService
    {
        Task<List<AsientoSesion>> GetAllAsync();
        Task<List<AsientoSesion>> GetBySesionAsync(int sesionId);
        Task AddAsync(AsientoSesion asientoSesion);
    }
}
