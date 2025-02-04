using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CineApi.Repositories
{
    public interface ITipoAlimentoRepository
    {
        Task<List<TipoAlimento>> GetAllAsync();
        Task<TipoAlimento?> GetByIdAsync(int id);
        Task AddAsync(TipoAlimento tipoAlimento);
        Task UpdateAsync(TipoAlimento tipoAlimento);
        Task DeleteAsync(int id);
    }
}
