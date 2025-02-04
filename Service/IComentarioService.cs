using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CineApi.Service
{
    public interface IComentarioService
    {
        Task<List<Comentario>> GetAllAsync();
        Task<Comentario?> GetByIdAsync(int id);
        Task<List<Comentario>> GetByPeliculaIdAsync(int peliculaId);
        Task AddAsync(Comentario comentario);
        Task UpdateAsync(Comentario comentario);
        Task DeleteAsync(int id);
    }
}
