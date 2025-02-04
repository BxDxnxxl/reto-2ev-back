using Models;
using CineApi.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CineApi.Service
{
    public class ComentarioService : IComentarioService
    {
        private readonly IComentarioRepository _comentarioRepository;

        public ComentarioService(IComentarioRepository comentarioRepository)
        {
            _comentarioRepository = comentarioRepository;
        }

        public async Task<List<Comentario>> GetAllAsync()
        {
            return await _comentarioRepository.GetAllAsync();
        }

        public async Task<Comentario?> GetByIdAsync(int id)
        {
            return await _comentarioRepository.GetByIdAsync(id);
        }

        public async Task<List<Comentario>> GetByPeliculaIdAsync(int peliculaId)
        {
            return await _comentarioRepository.GetByPeliculaIdAsync(peliculaId);
        }

        public async Task AddAsync(Comentario comentario)
        {
            await _comentarioRepository.AddAsync(comentario);
        }

        public async Task UpdateAsync(Comentario comentario)
        {
            await _comentarioRepository.UpdateAsync(comentario);
        }

        public async Task DeleteAsync(int id)
        {
            await _comentarioRepository.DeleteAsync(id);
        }
    }
}
