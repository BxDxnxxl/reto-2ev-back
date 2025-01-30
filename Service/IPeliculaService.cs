using Models;

namespace CineApi.Service
{
    public interface IPeliculaService
    {
        Task<List<Pelicula>> GetAllAsync();
        Task<Pelicula?> GetByIdAsync(int id);
        Task AddAsync(Pelicula pelicula);
        Task UpdateAsync(Pelicula pelicula);
        Task DeleteAsync(int id);
    }
}